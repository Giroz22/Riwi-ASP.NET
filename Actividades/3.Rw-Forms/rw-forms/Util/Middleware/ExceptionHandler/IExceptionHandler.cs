using RWFormsApi.API.DTOs.Errors;

public interface IExceptionHandler
{
    bool CanHandle(Exception ex);
    ErrorResponse Handle(Exception ex);
}