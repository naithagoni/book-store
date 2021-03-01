using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Address
    {
        [BsonElement("Street")]
        [JsonPropertyName("Street")]
        public string Street { get; set; }

        [BsonElement("Zip")]
        [JsonPropertyName("Zip")]
        public int Zip { get; set; }

        [BsonElement("City")]
        [JsonPropertyName("City")]
        public string City { get; set; }

        [BsonElement("State")]
        [JsonPropertyName("State")]
        public string State { get; set; }

        [BsonElement("Country")]
        [JsonPropertyName("Country")]
        public string Country { get; set; }
    }
}
