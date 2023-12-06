using MediatR;
using TvMaze.Auth.Models;

namespace TvMaze.Auth.Login
{
    public class LoginRequest : IRequest<JWTTokenResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
