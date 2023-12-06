using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvMaze.Application.ShowsMainInformation.Queries.GetShowMainInformation;

namespace TvMaze.Api.Controllers
{
    [ApiController]
    [Route("api/external-information")]
    [Authorize]
    public class ShowExternalInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShowExternalInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> ObtainShowInformation([FromQuery] GetShowMainInformationRequest request)
        {
            var response = await _mediator.Send(request, HttpContext.RequestAborted);

            return Ok(response);
        }
    }
}
