namespace Twitter.Services.Services.Abstractions
{
    public interface ITwitterUrlService
    {
        string AccessToken();
        string GetUserByUserNameUrl(string username, string? queryParams = null);
    }
}
