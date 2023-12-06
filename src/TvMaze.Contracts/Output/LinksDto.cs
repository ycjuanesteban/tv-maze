using Newtonsoft.Json;

namespace TvMaze.Contracts.Output
{
    public class LinksDto
    {
        public SelfDto Self { get; set; }
        public PreviousEpisodeDto Previousepisode { get; set; }
    }
}
