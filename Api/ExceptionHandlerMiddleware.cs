using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json;

namespace Api;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException ex)
        {
            await FormatResponse(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            await FormatResponse(StatusCodes.Status500InternalServerError, "Something went wrong, contact the administrator.");
        }

        async Task FormatResponse(int statusCode, string message)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(message));
        }
    }
}