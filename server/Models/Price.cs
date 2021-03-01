using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Price
    {
        [BsonElement("Retail")]
        [JsonPropertyName("Retail")]
        public string Retail { get; set; }

        [BsonElement("Sale")]
        [JsonPropertyName("Sale")]
        public string Sale { get; set; }
    }
}
