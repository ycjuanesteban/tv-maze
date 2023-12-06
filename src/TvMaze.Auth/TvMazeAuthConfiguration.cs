namespace TvMaze.Auth
{
    public class TvMazeAuthConfiguration
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Secret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
