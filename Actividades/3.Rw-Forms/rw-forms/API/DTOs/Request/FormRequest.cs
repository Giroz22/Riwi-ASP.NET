namespace RWFormsApi.API.DTOs.Request;

public class FormRequest
{
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public FormStatus Status { get; set;} = FormStatus.Private;
    public string UrlImage { get; set; } = "";
    public string UserId { get; set; } = "";
    public IEnumerable<SectionRequets> Sections{ get; set; } = new List<SectionRequets>();
}