namespace RWFormsApi.Domain.Entities;
public class ShortAnswerEntity : IAnswer
{
    public string Answer { get; set; } = string.Empty;

    public override IAnswer CreateAnswer(object? data)
    {
        return new ShortAnswerEntity { Answer = string.Empty };
    }
}