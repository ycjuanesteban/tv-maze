using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvMaze.Data.Repository;
using TvMaze.Domain.Abstraction.Repositories;

namespace TvMaze.Data.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<TvMazeContextConfigOptions>(configuration.GetSection(nameof(TvMazeContextConfigOptions)))
                .AddTransient<IShowMainInformationRepository, ShowMainInformationRepository>();
        }
    }
}
