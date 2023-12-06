namespace TvMaze.Contracts.Output
{
    public class CastDto
    {
        public PersonDto Person { get; set; }
        public CharacterDto Character { get; set; }
        public bool Self { get; set; }
        public bool Voice { get; set; }
    }
}
