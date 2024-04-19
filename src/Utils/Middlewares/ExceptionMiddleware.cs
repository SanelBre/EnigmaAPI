using System.Net;
using System.Text.Json;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Utils.Middlewares;

public class ExceptionMiddleware
{

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ForbiddenException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "application/json";
            var responseJson = JsonSerializer.Serialize(new
            {
                error = ex.Message ?? "You don't have permission to access this resource!"
            });
            await context.Response.WriteAsync(responseJson);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";
            var responseJson = JsonSerializer.Serialize(new
            {
                error = ex.Message ?? "Not Found!"
            });
            await context.Response.WriteAsync(responseJson);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var responseJson = JsonSerializer.Serialize(new { error = $"Internal Server Error: {ex.Message}" });

            await context.Response.WriteAsync(responseJson);
        }
    }
}

