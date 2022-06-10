using Twitter.Services.Extensions;
using Twitter.Services.Models.ResponseModels.TimeLine;
using Twitter.Services.Services.Abstractions;
namespace Twitter.Services.Services;
public class TimeLineService : ITimeLineService
{
    public TimeLineService(ITwitterUrlService twitterUrlService, IAuthenticationService authenticationService)
    {
        _twitterUrlService = twitterUrlService;
        _authenticationService = authenticationService;
    }

    public ITwitterUrlService _twitterUrlService { get; }
    public IAuthenticationService _authenticationService { get; }

    public async Task<TimeLineResponseModel?> GetUserTweetTimeLineAsync(string userId, Dictionary<string, string> paramas)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId));
        
        if (!await _authenticationService.GenerateAccessTokenAsync())
            throw new ArgumentNullException("unable to generate twitter token");

        var url = _twitterUrlService.GetUserByUserNameUrl(userId, paramas);

        HttpClient client = _authenticationService.GetAuthorizedClient();

        var httpResponse = await client.GetAsync(url);

        if (!httpResponse.IsSuccessStatusCode)
            return null;

        return await httpResponse.ParseResponseData<TimeLineResponseModel>();
    }
}
