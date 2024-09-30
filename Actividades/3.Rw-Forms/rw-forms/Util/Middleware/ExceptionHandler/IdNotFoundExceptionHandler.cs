using System.Net;
using RWFormsApi.API.DTOs.Errors;
using RWFormsApi.Util.Exceptions;

public class IdNotFoundExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception ex)
    {
        return ex is IdNotFoundException;
    }

    public ErrorResponse Handle(Exception ex)
    {
        var code = HttpStatusCode.NotFound;
        return new ErrorResponse{
            Code = code.GetHashCode(),
            Status = code.ToString(),
            Message = ex.Message,
        };
    }
}