using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TvMaze.Auth.Models;

namespace TvMaze.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, JWTTokenResponse>
    {
        private readonly TvMazeAuthConfiguration _options;

        public LoginHandler(IOptions<TvMazeAuthConfiguration> optionsSettings)
        {
            _options = optionsSettings.Value;
        }

        public Task<JWTTokenResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (ValidateUserAndPassword(request))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _options.ValidIssuer,
                    audience: _options.ValidAudience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );

                return Task.FromResult(new JWTTokenResponse()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions),
                    ValidLogin = true
                });
            }

            return Task.FromResult(new JWTTokenResponse()
            {
                ValidLogin = false
            });


        }

        private bool ValidateUserAndPassword(LoginRequest request)
        {
            string user = _options.UserName ?? "juanesteban";
            string password = _options.Password ?? "123456Aa!";

            return (request.UserName == user && request.Password == password);
        }
    }
}
