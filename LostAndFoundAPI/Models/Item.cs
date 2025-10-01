using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LostAndFound.API.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("location")]
        public string Location { get; set; } = string.Empty;

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [BsonElement("type")]
        public string Type { get; set; } = "lost"; // lost or found

        [BsonElement("status")]
        public string Status { get; set; } = "active"; // active, resolved, delivered

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [BsonElement("contactEmail")]
        public string ContactEmail { get; set; } = string.Empty;

        [BsonElement("contactPhone")]
        public string ContactPhone { get; set; } = string.Empty;

        [BsonElement("latitude")]
        public double? Latitude { get; set; }

        [BsonElement("longitude")]
        public double? Longitude { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; } = string.Empty;
    }
}