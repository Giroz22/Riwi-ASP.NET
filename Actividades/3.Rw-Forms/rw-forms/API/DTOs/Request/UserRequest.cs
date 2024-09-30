using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RWFormsApi.API.DTOs.Request;
public class UserRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string  Names { get; set; } = "";
    public string  LastNames { get; set; } = "";
    public string  Email { get; set; } = "";
    public string  Password { get; set; } = "";
}