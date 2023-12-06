using Newtonsoft.Json;

namespace TvMaze.Contracts.Output
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public CountryDto Country { get; set; }

        public string Birthday { get; set; }

        public object Deathday { get; set; }

        public string Gender { get; set; }

        public ImageDto Image { get; set; }

        public int Updated { get; set; }

        [JsonProperty("_links")]
        public LinksDto Links { get; set; }
    }
}
