using MediatR;
using Photo.Domain.Actions.Commands.ProcessImage;
using Photo.Domain.External.File;
using Photo.Domain.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Photo.BusinessLogic.Transformations;
using Photo.Domain.External.File.Common;

namespace Photo.BusinessLogic.Handlers.Command
{
    public class ProcessImageHandler : BaseHandler, IRequestHandler<ProcessImageCommand, ProcessImageCommandResponse>
    {
        private IFileRepository _fileRepository;

        public ProcessImageHandler(IUnitOfWork unitOfWork, IFileRepository fileRepository) : base(unitOfWork)
        {
            this._fileRepository = fileRepository;
        }

        public async Task<ProcessImageCommandResponse> Handle(ProcessImageCommand request, CancellationToken cancellationToken)
        {
            var fileByteArray = await this._fileRepository.GetFileByName(request.FileName);
            var bigThumbnail = await fileByteArray.BuiltThumbnailOfSize(500, 500);
            var mediumThumbnail = await fileByteArray.BuiltThumbnailOfSize(300, 300);
            var smallThumbnail = await fileByteArray.BuiltThumbnailOfSize(150, 150);
            var imageFromDb = await this._unitOfWork.PhotoImageRepository.FindById(request.Id);
            var largeThumbnailURL = await this._fileRepository.SaveFile(new ImageToSaveRequest { Data = bigThumbnail, FileName = $"{imageFromDb.Signature}x500.jpg"});
            var mediumThumbnailURL = await this._fileRepository.SaveFile(new ImageToSaveRequest { Data = mediumThumbnail, FileName = $"{imageFromDb.Signature}x300.jpg" });
            var smallThumbnailURL = await this._fileRepository.SaveFile(new ImageToSaveRequest { Data = smallThumbnail, FileName = $"{imageFromDb.Signature}x150.jpg" });
            imageFromDb.LargeThumbnailURL = largeThumbnailURL.URL;
            imageFromDb.MediumThumbnailURL = mediumThumbnailURL.URL;
            imageFromDb.SmallThumbnailURL = smallThumbnailURL.URL;
            imageFromDb.WasProcessed = true;
            await this._unitOfWork.PhotoImageRepository.Update(imageFromDb);
            await this._unitOfWork.Complete();
            return new ProcessImageCommandResponse
            {
                LargeThumbnailURL = imageFromDb.LargeThumbnailURL,
                MediumThumbnailURL = imageFromDb.MediumThumbnailURL,
                SmallThumbnailURL = imageFromDb.SmallThumbnailURL,
                Id = request.Id,
                Name = imageFromDb.Name,
                OriginalImageURL = imageFromDb.OriginalImageURL,
                Proccessed = true
            };
        }
    }
}
