namespace RWFormsApi.API.DTOs.Response;
public class QuestionResponse
{
    public string Question { set; get; } = "";
    public string TypeQuestion { set; get; } = QuestionType.Short.ToString();
    public object Answer { set; get; } = new(); 

}