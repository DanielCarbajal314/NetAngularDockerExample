using MediatR;
using Photo.Domain.Actions.Query.ListImages;
using Photo.Domain.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Handlers.Query
{
    public class ListImagesHandler : BaseHandler, IRequestHandler<ListImagesQuery, IEnumerable<ListImagesQueryResponseItem>>
    {
        public ListImagesHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<ListImagesQueryResponseItem>> Handle(ListImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await this._unitOfWork.PhotoImageRepository.GetAll();
            return images.Select(image => new ListImagesQueryResponseItem
            {
                Id = image.Id,
                LargeThumbnailURL = image.LargeThumbnailURL,
                MediumThumbnailURL = image.MediumThumbnailURL,
                SmallThumbnailURL = image.SmallThumbnailURL,
                OriginalImageURL = image.OriginalImageURL,
                Name = image.Name,
                Proccessed = image.WasProcessed
            });
        }
    }
}
