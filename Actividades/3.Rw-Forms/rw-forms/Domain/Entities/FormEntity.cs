using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RWFormsApi.Domain.Entities;
public class FormEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public FormStatus Status { get; set;} = FormStatus.Private;
    public string UrlImage { get; set; } = "";
    public UserEntity User { get; set; } = new UserEntity();
    public IEnumerable<SectionEntity> Sections{ get; set; } = new List<SectionEntity>();
}