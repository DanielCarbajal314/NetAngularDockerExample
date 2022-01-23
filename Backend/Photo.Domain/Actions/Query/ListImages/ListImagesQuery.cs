using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Actions.Query.ListImages
{
    public class ListImagesQuery: IRequest<IEnumerable<ListImagesQueryResponseItem>>
    {
    }
}
