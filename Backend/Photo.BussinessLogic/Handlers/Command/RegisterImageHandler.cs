using MediatR;
using Photo.BusinessLogic.Transformations;
using Photo.Domain.Actions.Commands.RegisterImage;
using Photo.Domain.Common;
using Photo.Domain.Entities;
using Photo.Domain.External.File;
using Photo.Domain.External.File.Common;
using Photo.Domain.External.Queu;
using Photo.Domain.External.Queu.DTO;
using Photo.Domain.Persistency;
using System.Threading;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Handlers.Command
{
    public class RegisterImageHandler : BaseHandler, IRequestHandler<RegisterImageCommand, RegisterImageCommandResponse>
    {
        private IFileRepository _fileRepository;
        private IRegisteredImageBus _registeredImageBus;

        public RegisterImageHandler(IUnitOfWork unitOfWork, IFileRepository fileRepository, IRegisteredImageBus registeredImageBus) : base(unitOfWork)
        {
            this._fileRepository = fileRepository;
            this._registeredImageBus = registeredImageBus;
        }

        public async Task<RegisterImageCommandResponse> Handle(RegisterImageCommand request, CancellationToken cancellationToken)
        {
            var imageByteArray = request.Data.ToArray();
            var fileSignarure = imageByteArray.CalculateMD5Signature();
            var fileType = imageByteArray.GetImageType();
            await validateRequest(fileSignarure, fileType);
            var fileNameOnRepo = $"{fileSignarure}.{fileType}";
            var savedImageOnFileRepository = await this._fileRepository.SaveFile(new ImageToSaveRequest { FileName = fileNameOnRepo, Data = imageByteArray });
            var imageToSave = new PhotoImage
            {
                Name = request.ImageName,
                FileName = fileNameOnRepo,
                Signature = fileSignarure,
                OriginalImageURL = savedImageOnFileRepository.URL
            };
            var savedImageOnDatabase = await this._unitOfWork.PhotoImageRepository.Register(imageToSave);
            await this._unitOfWork.Complete();
            await this._registeredImageBus.Queu(new RegisteredImage
            {
                Id = savedImageOnDatabase.Id,
                ImageName = fileNameOnRepo
            });
            return new RegisterImageCommandResponse
            {
                Id = savedImageOnDatabase.Id,
                Name = request.ImageName,
                OriginalImageURL = savedImageOnFileRepository.URL
            };
        }

        private async Task validateRequest(string fileSignarure, string fileType)
        {
            if (fileType == null)
            {
                throw new PhotoBadOperationException("Not Allowed format for an Image");
            }
            var signatureIsRegister = await this._unitOfWork.PhotoImageRepository.SignatureExist(fileSignarure);
            if (signatureIsRegister)
            {
                throw new PhotoBadOperationException("Image was already registered");
            }
        }
    }
}
