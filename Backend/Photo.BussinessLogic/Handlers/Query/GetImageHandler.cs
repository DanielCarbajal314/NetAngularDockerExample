using MediatR;
using Photo.Domain.Actions.Query.GetImage;
using Photo.Domain.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Handlers.Query
{
    public class GetImageHandler : BaseHandler, IRequestHandler<GetImageQuery, GetImageQueryResponse>
    {
        public GetImageHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<GetImageQueryResponse> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var image = await this._unitOfWork.PhotoImageRepository.FindById(request.Id);
            return new GetImageQueryResponse
            {
                Id = image.Id,
                LargeThumbnailURL = image.LargeThumbnailURL,
                MediumThumbnailURL = image.MediumThumbnailURL,
                SmallThumbnailURL = image.SmallThumbnailURL,
                OriginalImageURL = image.OriginalImageURL,
                Name = image.Name,
                WasProcessed = image.WasProcessed
            };
        }
    }
}
