using RWFormsApi.Domain.Entities;

namespace RWFormsApi.API.DTOs.Response;
public class FormResponse
{
    public string? Id { get; set; }
    public string Title{ get; set; } = "";
    public string Description{ get; set; } = "";
    public FormStatus Status { get; set;} = FormStatus.Private;
    public string UrlImage { get; set; } = "";
    public UserResponse User { get; set; } = new UserResponse();
    public IEnumerable<SectionEntity> Sections{ get; set; } = [];
}