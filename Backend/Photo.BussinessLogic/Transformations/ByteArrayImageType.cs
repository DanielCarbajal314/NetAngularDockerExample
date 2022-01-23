using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Transformations
{
    public static class ByteArrayImageType
    {
        public static string GetImageType(this byte[] data)
        {
            var imgeTypes = new[]
            {
                new { signature = "FFD8", type = "jpg"},
                new { signature = "89504E470D0A1A0A", type = "png"}
            };
            var str = System.Text.Encoding.Default.GetString(data);
            return imgeTypes.FirstOrDefault(x => str.StartsWith(x.signature))?.type ?? null;
        }
    }
}
