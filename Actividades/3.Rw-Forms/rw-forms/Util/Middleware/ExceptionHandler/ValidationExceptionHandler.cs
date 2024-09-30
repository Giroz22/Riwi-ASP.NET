using System.Net;
using FluentValidation;
using RWFormsApi.API.DTOs.Errors;

public class ValidationExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception ex)
    {
        return ex is ValidationException;
    }

    public ErrorResponse Handle(Exception ex)
    {
        var code = HttpStatusCode.BadRequest;

        List<string> errors = [];
        foreach (var error in ((ValidationException)ex).Errors)
        {
            errors.Add(error.ErrorMessage);
        }

        return new ErrorsResponse{
            Code = code.GetHashCode(),
            Status = code.ToString(),
            Message = "Validation failed",
            Errors = errors
        };
    }
}