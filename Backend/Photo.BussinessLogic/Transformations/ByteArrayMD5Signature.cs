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
                byte[] hashBytes = md5.ComputeHash(dataByteArray);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
