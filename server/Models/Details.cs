using System;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Details
    {
        [BsonElement("Weight")]
        [JsonPropertyName("Weight")]
        public string Weight { get; set; }

        [BsonElement("ISBN")]
        [JsonPropertyName("ISBN")]
        public string ISBN { get; set; }

        [BsonElement("Publisher")]
        [JsonPropertyName("Publisher")]
        public string Publisher { get; set; }

        [BsonElement("PublishedDate")]
        [JsonPropertyName("PublishedDate")]
        public DateTime PublishedDate { get; set; }

        [BsonElement("Language")]
        [JsonPropertyName("Language")]
        public string Language { get; set; }

        [BsonElement("Pages")]
        [JsonPropertyName("Pages")]
        public int Pages { get; set; }
    }
}
