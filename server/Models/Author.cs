using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Author
    {
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [BsonElement("Address")]
        [JsonPropertyName("Address")]
        public Address Address { get; set; }
    }
}
