using Photo.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Entities
{
    public class PhotoImage : Entity
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string OriginalImageURL { get; set; }
        public string LargeThumbnailURL { get; set; }
        public string MediumThumbnailURL { get; set; }
        public string SmallThumbnailURL { get; set; }
        public string Signature { get; set; }
        public bool WasProcessed { get; set; } = false;
    }
}
