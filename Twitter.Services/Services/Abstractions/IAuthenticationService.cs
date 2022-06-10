namespace Twitter.Services.Services.Abstractions;
public interface IAuthenticationService
{
    HttpClient GetAuthorizedClient();
    Task<bool> GenerateAccessToken();
    string GetAccessToken();
}
