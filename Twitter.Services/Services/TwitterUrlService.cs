using System.Web;
using Twitter.Services.Services.Abstractions;
using Twitter.Services.Utilities;

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
    public string GetUserByUserNameUrl(string username, Dictionary<string, string> paramas)
    {
        var queryParamas = Utility.GetQueryParams(paramas);
        if (string.IsNullOrEmpty(queryParamas))
            return $"{_baseURL}/2/users/by/username/{username}";
        return $"{_baseURL}/2/users/by/username/{username}?{queryParamas}";
    }

    #endregion

    #region timeline
    public string GetUserTweetTimeLineUrl(string userId, Dictionary<string, string> paramas)
    {
        var queryParamas = Utility.GetQueryParams(paramas);
        if (string.IsNullOrEmpty(queryParamas))
            return $"{_baseURL}2/users/{userId}/tweets";
        return $"{_baseURL}/2/users/{userId}/tweets?{queryParamas}";
    }
    #endregion
}
