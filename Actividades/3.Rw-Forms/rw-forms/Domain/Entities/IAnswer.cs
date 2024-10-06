using MongoDB.Bson.Serialization.Attributes;

namespace RWFormsApi.Domain.Entities;

[BsonDiscriminator(Required = true)]
[BsonKnownTypes(typeof(ShortAnswerEntity), typeof(OptionsAnswerEntity))]
public abstract class IAnswer
{
    public abstract IAnswer CreateAnswer(object data);
}