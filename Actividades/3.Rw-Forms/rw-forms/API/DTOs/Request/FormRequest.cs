namespace RWFormsApi.API.DTOs.Request;

public class FormRequest
{
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public string Status { get; set;} = FormStatus.Private.ToString();
    public string UrlImage { get; set; } = "";
    public string UserId { get; set; } = "";
    public IEnumerable<SectionRequets> Sections{ get; set; } = new List<SectionRequets>();
}