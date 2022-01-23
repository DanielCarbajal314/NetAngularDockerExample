using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Actions.Commands.RegisterImage
{
    public class RegisterImageCommand : IRequest<RegisterImageCommandResponse>
    {
        public string ImageName { get; set; }
        public MemoryStream Data { get; set; }
    }
}
