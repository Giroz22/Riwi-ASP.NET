using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RWFormsApi.Domain.Entities;

public class FormResponse
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime ResolvedDate { get; set; }
    public FormEntity Form { get; set; } = new FormEntity(); 
}