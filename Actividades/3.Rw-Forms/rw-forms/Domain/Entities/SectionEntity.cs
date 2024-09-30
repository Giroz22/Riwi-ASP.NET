namespace RWFormsApi.Domain.Entities;
public class SectionEntity
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public ICollection<QuestionEntity> Questions { get; set; } = []; 
}