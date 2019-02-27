using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KeyloggerController
{
    class classGetEncryption
    {
        //Encrypts the Json object with Bson once called
        public static string encryptBson(classJsonObj.classJson objJson)
        {
            MemoryStream ms = new MemoryStream();
            using (BsonWriter writer = new BsonWriter(ms)) //Reads the encrypted data
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, objJson); //Serializes the json using bson
            }

            string data = Convert.ToBase64String(ms.ToArray()); //Base64 encryption

            return data; //returns the encrypted data
        }
    }
}
