namespace RWFormsApi.API.DTOs.Response;

public class SectionResponse
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>(); 
}