using TvMaze.Api.Extensions;
using TvMaze.Api.Host.Extensions;

namespace TvMaze.Api.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();

            builder.Services
                .AddEndpointsApiExplorer()
                .AddCustomSwagger()
                .ConfigureAppiServices(builder.Configuration)
                .AddCustomAuthentication(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            app.UseSwagger();
            app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
