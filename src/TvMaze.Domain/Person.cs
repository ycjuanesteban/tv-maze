using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TvMaze.Domain
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PersonId { get; set; }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Birthday { get; set; }
        public object Deathday { get; set; }
        public string Gender { get; set; }
        public Image Image { get; set; }
        public int Updated { get; set; }
        public Links Links { get; set; }
    }
}
