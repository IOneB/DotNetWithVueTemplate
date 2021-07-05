using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MongoBongo.Models
{
    public class Work
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string WorkName { get; set; }

        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        None = 0,
        Low = 1,
        Medium = 3,
        High = 5
    }
}
