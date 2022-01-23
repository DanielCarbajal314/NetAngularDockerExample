using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Common
{
    public class PhotoNonFoundException : Exception
    {
        public PhotoNonFoundException(string message) : base(message) { }
    }
}
