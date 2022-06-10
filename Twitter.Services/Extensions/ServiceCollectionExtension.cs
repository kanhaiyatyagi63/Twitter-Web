using Microsoft.Extensions.DependencyInjection;
using Twitter.Services.Models.Core;
using Twitter.Services.Services;
using Twitter.Services.Services.Abstractions;

namespace Twitter.Services.Extensions;
public static class ServiceCollectionExtension
{
    private static void AddTwitterServices(this IServiceCollection services, TwitterSettings twitterSetting)
    {
        services.AddScoped<IAuthenticationService>(factory =>
        {
            return new AuthenticationService(twitterSetting);
        });

        services.AddScoped<ITwitterUrlService>(factory =>
        {
            return new TwitterUrlService(twitterSetting.Url);
        });

        services.AddScoped<ITweetService, TweetService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITwitterWorkerService, TwitterWorkerService>();
    }

    public static void AddTwitter(this IServiceCollection services, Action<TwitterSettings> configureTwitterSettings)
    {
        TwitterSettings twitterSettings = new();

        configureTwitterSettings(twitterSettings);

        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddTwitterServices(twitterSettings);

    }
}

