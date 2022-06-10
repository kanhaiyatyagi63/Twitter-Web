using Newtonsoft.Json;

namespace Twitter.Services.Models.ResponseModels.Authentication
{
    public class AccessTokenResponseModel
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
