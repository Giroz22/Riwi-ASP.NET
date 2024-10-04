namespace RWFormsApi.Domain.Entities;
public abstract class QuestionEntity
{
    public string Description { set; get; } = "";
    public QuestionType TypeQuestion { set; get; } = QuestionType.ShortAnswer;
    public IAnswer Answer { set; get; } = new ShortAnswerEntity();
}