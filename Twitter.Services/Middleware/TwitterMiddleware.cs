using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Twitter.Services.Middleware;
public class TwitterMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<TwitterMiddleware> _logger;
    public TwitterMiddleware(RequestDelegate next, ILogger<TwitterMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            _logger.LogDebug("Invoked Twitter API");
            await _next(context);
        }
        catch (Exception error)
        {
            _logger.LogError("Something went wrong", error);
        }
    }
}
