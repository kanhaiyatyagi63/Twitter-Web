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

    #region user
    public string GetUserByUserNameUrl(string username, string? queryParams = null)
    { 
        if (string.IsNullOrEmpty(queryParams))
            return $"{_baseURL}/2/users/by/username/{username}";
        return $"{_baseURL}/2/users/by/username/{username}?{queryParams}";
    }

    #endregion
}
