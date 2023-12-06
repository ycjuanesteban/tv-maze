using Newtonsoft.Json;

namespace TvMaze.Contracts.Output
{
    public class ShowMainInformationDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public List<string> Genres { get; set; }
        public string Status { get; set; }
        public int Runtime { get; set; }
        public int AverageRuntime { get; set; }
        public string Premiered { get; set; }
        public string Ended { get; set; }
        public string OfficialSite { get; set; }
        public ScheduleDto Schedule { get; set; }
        public RatingDto Rating { get; set; }
        public int Weight { get; set; }
        public NetworkDto Network { get; set; }
        public object WebChannel { get; set; }
        public object DvdCountry { get; set; }
        public ExternalsDto Externals { get; set; }
        public ImageDto Image { get; set; }
        public string Summary { get; set; }
        public int Updated { get; set; }

        [JsonProperty("_links")]
        public LinksDto Links { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedDto Embedded { get; set; }
    }
}
