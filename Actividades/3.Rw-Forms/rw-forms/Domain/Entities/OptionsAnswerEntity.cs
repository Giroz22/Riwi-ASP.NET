namespace RWFormsApi.Domain.Entities;

public class OptionsAnswerEntity : IAnswer
{
    public OptionsAnswerEntity() : base( new List<Dictionary<string, bool>>() )
    {

    }
}