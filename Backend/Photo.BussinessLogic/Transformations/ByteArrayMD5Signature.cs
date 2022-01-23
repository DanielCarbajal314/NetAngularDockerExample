using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Transformations
{
    public static class ByteArrayMD5Signature
    {
        public static string CalculateMD5Signature(this byte[] dataByteArray) 
        {
            using (var md5 = MD5.Create())
            {
                var signature = md5.TransformFinalBlock(dataByteArray, 0, dataByteArray.Length);
                var hashBuilder = new StringBuilder();
                for (int i = 0; i < signature.Length; i++)
                {
                    hashBuilder.Append(signature[i].ToString("x2"));
                }
                return hashBuilder.ToString();
            }
        }
    }
}
