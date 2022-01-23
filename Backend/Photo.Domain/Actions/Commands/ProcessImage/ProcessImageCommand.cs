using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Actions.Commands.ProcessImage
{
    public class ProcessImageCommand : IRequest<ProcessImageCommandResponse>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}
