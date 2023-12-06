namespace TvMaze.Contracts.Output
{
    public class NetworkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto Country { get; set; }
        public string OfficialSite { get; set; }
    }
}
