namespace RWFormsApi.API.DTOs.Request;
public class QuestionRequest
{
    public string Question { set; get; } = "";
    public string TypeQuestion { set; get; } = QuestionType.ShortAnswer.ToString();
    // public object Answer { set; get; } = new ShortAnswerEntity();
}