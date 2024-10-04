using RWFormsApi.API.DTOs.Errors;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

    public ExceptionMiddleware(RequestDelegate next,  IEnumerable<IExceptionHandler> exceptionHandlers)
    {
        _next = next;
        _exceptionHandlers = exceptionHandlers;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var handler = _exceptionHandlers.FirstOrDefault(h => h.CanHandle(exception));

        //Defaul error
        ErrorResponse errorResponse = handler?.Handle(exception) ?? new ErrorResponse
        {
            Code = (int)HttpStatusCode.InternalServerError,
            Status = "Error",
            Message = exception.Message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResponse.Code;

        if(errorResponse is ErrorsResponse errors) return context.Response.WriteAsJsonAsync(errors);
        
        System.Console.WriteLine(exception);
        return context.Response.WriteAsJsonAsync(errorResponse);            
    }
}
