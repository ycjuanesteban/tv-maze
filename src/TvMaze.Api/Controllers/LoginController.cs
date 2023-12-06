using MediatR;
using Microsoft.AspNetCore.Mvc;
using TvMaze.Auth.Login;

namespace TvMaze.Api.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> ObtainShowInformation([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("User and/or password empty");
            }

            var loginResponse = await _mediator.Send(request, HttpContext.RequestAborted);

            if (loginResponse.ValidLogin)
            {
                return Ok($"Bearer {loginResponse.Token}");
            }
            else
            {
                return Unauthorized();
            }


        }
    }
}
