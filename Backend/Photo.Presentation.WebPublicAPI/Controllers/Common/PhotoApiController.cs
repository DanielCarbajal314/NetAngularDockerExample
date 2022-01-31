using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Photo.Presentation.WebPublicAPI.Controllers.Common
{

    [ApiController]
    [Route("api/[controller]")]
    public class PhotoApiController : ControllerBase
    {
        protected IMediator _mediator;

        public PhotoApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
