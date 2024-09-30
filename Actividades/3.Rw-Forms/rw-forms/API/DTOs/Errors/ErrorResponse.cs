namespace RWFormsApi.API.DTOs.Errors;

public class ErrorResponse
{
    public string Status { get; set; } = "";
    public int Code { get; set; }
    public string Message { get; set; } = "";
}