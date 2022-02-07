using Photo.Domain.External.Queu.Common;
using Photo.Domain.External.Queu.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.External.Queu
{
    public interface IRegisteredImageBus : IQueuBus<RegisteredImage>
    {
    }
}
