using Microsoft.AspNetCore.Builder;
using Twitter.Services.Middleware;
namespace Twitter.Services.Extensions;
public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseTwitter(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<TwitterMiddleware>();
        return builder;
    }
}
