using System.Web;
using Twitter.Services.Models.Core;
using Twitter.Services.Services.Abstractions;
using Twitter.Services.Utilities;

namespace Twitter.Services.Services;
public class TwitterUrlService : ITwitterUrlService
{
    private readonly string _baseURL;
    private readonly string _maxResult;
    public TwitterUrlService(TwitterSettings twitterSettings)
    {
        if (string.IsNullOrEmpty(twitterSettings.Url))
            throw new ArgumentNullException(nameof(twitterSettings.Url));
        _baseURL = twitterSettings.Url;
        _maxResult = twitterSettings.TweetCount;
    }

    public string AccessToken()
    {
        return $"{_baseURL}/oauth2/token";
    }
    public string MaxResultForQuery()
    {
        if (string.IsNullOrEmpty(_maxResult))
            return "10"; // default max result
        return _maxResult;
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
            return $"{_baseURL}/2/users/{userId}/tweets";
        return $"{_baseURL}/2/users/{userId}/tweets?{queryParamas}";
    }
    #endregion
}
