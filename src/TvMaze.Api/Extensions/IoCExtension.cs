using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvMaze.Application.Mappers;
using TvMaze.Application.ShowsMainInformation.Queries.GetShowMainInformation;
using TvMaze.Auth.Extensions;
using TvMaze.Client.Http;
using TvMaze.Contracts;
using TvMaze.Data.Extensions;

namespace TvMaze.Api.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection ConfigureAppiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureRepositories(configuration)
                .ConfigureAuth(configuration)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetShowMainInformationRequest).Assembly))
                .AddAutoMapper(typeof(GenericMappers).Assembly)
                .Configure<TvMazeServiceClientOptions>(configuration.GetSection(nameof(TvMazeServiceClientOptions)))
                    .AddHttpClient<ITvMazeServiceClient, TvMazeServiceClient>();

            return services;
        }
    }
}
