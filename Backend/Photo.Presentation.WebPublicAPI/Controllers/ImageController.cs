using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Photo.Domain.Actions.Commands.RegisterImage;
using Photo.Domain.Actions.Query.GetImage;
using Photo.Domain.Actions.Query.ListImages;
using Photo.Presentation.WebPublicAPI.Controllers.Common;
using Photo.Presentation.WebPublicAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Presentation.WebPublicAPI.Controllers
{
    public class ImageController : PhotoApiController
    {
        public ImageController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<RegisterImageCommandResponse> Post([FromForm] RegisterImage request)
        {
            using var memoryStream = new MemoryStream();
            await request.FileContent.CopyToAsync(memoryStream);
            var command = new RegisterImageCommand
            {
                Data = memoryStream,
                ImageName = request.FileName
            };
            return await this._mediator.Send(command);
        }

        [HttpGet("{Id}")]
        public async Task<GetImageQueryResponse> GetById([FromRoute] GetImageQuery request)
        {
            return await this._mediator.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<ListImagesQueryResponseItem>> GetById([FromQuery] ListImagesQuery request)
        {
            return await this._mediator.Send(request);
        }

    }
}
