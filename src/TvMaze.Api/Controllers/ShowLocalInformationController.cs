using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvMaze.Application.ShowInformationFromDB.Queries.GetAllFromDB;

namespace TvMaze.Api.Controllers
{
    [ApiController]
    [Route("api/local-information")]
    [Authorize]
    public class ShowLocalInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShowLocalInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetInformationFromDB()
        {
            var allData = await _mediator.Send(new GetAllFromDBRequest(), HttpContext.RequestAborted);

            return Ok(allData);
        }
    }
}
