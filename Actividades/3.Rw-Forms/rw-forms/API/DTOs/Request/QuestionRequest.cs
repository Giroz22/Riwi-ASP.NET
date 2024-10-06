namespace RWFormsApi.API.DTOs.Request;
public class QuestionRequest
{
    public string Question { set; get; } = "";
    public QuestionType TypeQuestion { set; get; } = QuestionType.Short;
    public object Answer { set; get; } = new();

}