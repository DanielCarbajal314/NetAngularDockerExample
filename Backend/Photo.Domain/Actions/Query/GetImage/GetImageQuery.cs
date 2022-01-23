using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Actions.Query.GetImage
{
    public class GetImageQuery : IRequest<GetImageQueryResponse>
    {
        public int Id { get; set; }
    }
}
