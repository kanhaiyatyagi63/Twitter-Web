using System.Net.Http.Headers;
using System.Text;
using Twitter.Services.Extensions;
using Twitter.Services.Models.Core;
using Twitter.Services.Models.ResponseModels.Authentication;
using Twitter.Services.Services.Abstractions;

namespace Twitter.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string _basicToken;
        private string AccessToken { get; set; } = string.Empty;
        private readonly TwitterSettings _twitterSettings;
        private readonly ITwitterUrlService _twitterUrlService;
        public AuthenticationService(TwitterSettings twitterSettings)
        {
            _twitterSettings = twitterSettings;
            _twitterUrlService = new TwitterUrlService(twitterSettings.Url);
            _basicToken = ConvertSettingsIntoBase64(twitterSettings.ClientId, twitterSettings.ClientSecret);
        }

        #region private methods
        private string ConvertSettingsIntoBase64(string clientId, string clientSecret)
        {
            var bytes = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
            return Convert.ToBase64String(bytes);
        }
        #endregion

        public async Task<bool> GenerateAccessToken()
        {
            if (!string.IsNullOrWhiteSpace(AccessToken))
                return true;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {_basicToken}");

            var stringContent = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var httpResponse = await client.PostAsync(_twitterUrlService.AccessToken(), stringContent);
            if (!httpResponse.IsSuccessStatusCode)
                return false;

            var accessTokenData = await httpResponse.ParseResponseData<AccessTokenResponseModel>();
            if (accessTokenData != null)
                AccessToken = accessTokenData.AccessToken;

            return !string.IsNullOrWhiteSpace(AccessToken);
        }
        public string GetAccessToken()
        {
            return AccessToken;
        }
        public HttpClient GetAuthorizedClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
            return client;
        }
    }
}
