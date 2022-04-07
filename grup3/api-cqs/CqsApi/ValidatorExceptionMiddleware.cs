using FluentValidation;
using System.Text.Json;

namespace CqsApi;
internal sealed class ValidationExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ValidationExceptionMiddleware> _logger;
    public ValidationExceptionMiddleware(ILogger<ValidationExceptionMiddleware> logger) => _logger = logger;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext httpContext, ValidationException exception)
    {
        var statusCode = StatusCodes.Status400BadRequest;
        var response = new
        {
            title = "Bad Request",
            status = statusCode,
            detail = exception.Message,

            errors = exception.Errors.Select(e => new { Property = e.PropertyName, Message = e.ErrorMessage })
        };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}
