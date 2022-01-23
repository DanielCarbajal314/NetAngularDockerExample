using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.External.File.Common
{
    public class ImageToSaveRequest
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
