using MongoDB.Bson.Serialization.Attributes;

namespace RESTApi.Entities
{
    public record Item
    {
        [BsonId]
        public Guid Id { get; init; }
        [BsonElement("Name")]
        public string? Name { get; init; }
        [BsonElement("Price")]
        public decimal Price { get; init; }
        [BsonElement("CreatedDate")]
        public DateTimeOffset CreatedDate { get; init; }
    }
}
