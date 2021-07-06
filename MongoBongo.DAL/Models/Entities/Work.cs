using MongoBongo.DAL.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MongoBongo.DAL.Models.Entities
{
    public class Work : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string WorkName { get; set; }

        public Priority Priority { get; set; }
    }
}
