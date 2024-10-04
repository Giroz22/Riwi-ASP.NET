namespace RWFormsApi.Domain.Entities;
public class FormRequest
{
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public FormStatus Status { get; set;} = FormStatus.Private;
    public string UrlImage { get; set; } = "";
    public string UserId { get; set; } = "";
    public IEnumerable<SectionEntity> Sections{ get; set; } = [];
}