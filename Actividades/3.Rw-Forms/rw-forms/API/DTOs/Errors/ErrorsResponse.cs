namespace RWFormsApi.API.DTOs.Errors;

public class ErrorsResponse : ErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = [];
}