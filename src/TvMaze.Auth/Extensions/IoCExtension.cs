using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvMaze.Auth.Login;

namespace TvMaze.Auth.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<TvMazeAuthConfiguration>(configuration.GetSection(nameof(TvMazeAuthConfiguration)))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginHandler).Assembly));

            return services;
        }
    }
}
