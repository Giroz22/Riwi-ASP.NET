namespace RWFormsApi.Domain.Entities;
public class QuestionEntity
{
    public string Question { set; get; } = "";
    public QuestionType TypeQuestion { set; get; } = QuestionType.Short;
    public IAnswer Answer { set; get; } = new ShortAnswerEntity();
}