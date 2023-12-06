namespace TvMaze.Auth.Models
{
    public class JWTTokenResponse
    {
        public string? Token { get; set; }
        public bool ValidLogin { get; set; }
    }
}
