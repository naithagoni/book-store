using MongoDB.Bson;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Book
    {
        [BsonId]
        [JsonPropertyName("Id")]
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [BsonElement("Category")]
        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [BsonElement("Description")]
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [BsonElement("Tags")]
        [JsonPropertyName("Tags")]
        public List<string> Tags { get; set; }

        [BsonElement("Price")]
        [JsonPropertyName("Price")]
        public Price Price { get; set; }

        [BsonElement("Details")]
        [JsonPropertyName("Details")]
        public Details Details { get; set; }

        [BsonElement("Author")]
        [JsonPropertyName("Author")]
        public List<Author> Author { get; set; }
    }
}
