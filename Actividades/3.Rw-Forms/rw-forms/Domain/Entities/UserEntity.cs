using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RWFormsApi.Domain.Entities;
public class UserEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string  Names { get; set; } = "";
    public string  LastNames { get; set; } = "";
    public string  Email { get; set; } = "";
    public string  Password { get; set; } = "";
}