namespace RWFormsApi.API.DTOs.Request;

public class SectionRequets
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<QuestionRequest> Questions { get; set; } = new List<QuestionRequest>(); 
}