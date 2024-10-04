namespace RWFormsApi.Domain.Entities;

public abstract class IAnswer
{
    public object Answer { get; set; }

    public IAnswer(object answer)
    {
        Answer = answer;
    }
}