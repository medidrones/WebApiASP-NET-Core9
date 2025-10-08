using MasterNet9.Application.Core;
using Newtonsoft.Json;

namespace MasterNet9.WebApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;    

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;        
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var response = ex switch
            {
                ValidationException validationException => new AppException(
                    StatusCodes.Status400BadRequest,
                    "Error de validacion",
                    string.Join (", ", validationException.Errors.Select(er => er.ErrorMessage))),
                _ => new AppException(
                    context.Response.StatusCode,
                    ex.Message,
                    ex.StackTrace?.ToString())                    
            };

            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(response);

            await context.Response.WriteAsync(json);
        }
    }
}
