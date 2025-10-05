using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectTracker.API.Models
{
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = "Todo"; // Todo, InProgress, Done

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}