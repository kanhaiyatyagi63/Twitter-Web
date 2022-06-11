namespace Twitter.Services.Services.Abstractions
{
    public interface ITwitterUrlService
    {
        string AccessToken();
        string GetUserByUserNameUrl(string username, Dictionary<string, string> paramas);
        string GetUserTweetTimeLineUrl(string userId, Dictionary<string, string> paramas);
        string MaxResultForQuery();
    }
}
