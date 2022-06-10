using Twitter.Services.Services.Abstractions;

namespace Twitter.Services.Services;
public class TwitterUrlService : ITwitterUrlService
{
    private readonly string _baseURL;
    public TwitterUrlService(string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentNullException(nameof(url));
        _baseURL = url;
    }
    public string AccessToken()
    {
        return $"{_baseURL}/oauth2/token";
    }
}
