using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TvMaze.Client.Http.Extensions;
using TvMaze.Contracts;
using TvMaze.Contracts.Output;

namespace TvMaze.Client.Http
{
    public class TvMazeServiceClient : ITvMazeServiceClient
    {
        private const string MainInfo = "/shows/{0}";
        private const string MainInfoWithEmbedCast = $"{MainInfo}?embed=cast";

        private readonly HttpClient _httpClient;

        public TvMazeServiceClient(HttpClient httpClient, IOptions<TvMazeServiceClientOptions> options)
        {
            httpClient.BaseAddress = new Uri(options.Value.BaseAddress);
            _httpClient = httpClient;
        }

        public async Task<ShowMainInformationDto> GetShowInformation(int id, bool withCast = false, CancellationToken cancellationToken = default)
        {
            string requestUrl = withCast ? String.Format(MainInfoWithEmbedCast, id) : String.Format(MainInfo, id);

            var response = await _httpClient.GetAsync(requestUrl, cancellationToken);
            await response.ValidateStatusCodes();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<ShowMainInformationDto>(responseContent);
        }
    }
}
