using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryApi.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string API_KEY = "MIDTERM_KEY_123";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if(!context.Request.Headers.TryGetValue("X-api-key",out var key) || key != API_KEY)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                error = "Unauthorized",
                message = "Missing or invalid API Key."
            });

            await context.Response.WriteAsync(result);
            return;
        }
        
        await _next(context);
    }
}