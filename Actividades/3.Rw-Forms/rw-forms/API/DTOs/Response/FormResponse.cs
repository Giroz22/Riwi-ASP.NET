using RWFormsApi.Domain.Entities;

namespace RWFormsApi.API.DTOs.Response;
public class FormResponse
{
    public string? Id { get; set; }
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public string Status { get; set;} = FormStatus.Private.ToString();
    public string UrlImage { get; set; } = "";
    public UserResponse User { get; set; } = new UserResponse();
    public IEnumerable<SectionResponse> Sections{ get; set; } = new List<SectionResponse>();
}