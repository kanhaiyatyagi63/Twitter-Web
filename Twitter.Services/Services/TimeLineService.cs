using Twitter.Services.Constants;
using Twitter.Services.Extensions;
using Twitter.Services.Models.ResponseModels.TimeLine;
using Twitter.Services.Services.Abstractions;
namespace Twitter.Services.Services;
public class TimeLineService : ITimeLineService
{
    public TimeLineService(ITwitterUrlService twitterUrlService,
                           IAuthenticationService authenticationService,
                           IUserService userService)
    {
        _twitterUrlService = twitterUrlService;
        _authenticationService = authenticationService;
        _userService = userService;
    }

    private readonly ITwitterUrlService _twitterUrlService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;

    public async Task<TimeLineResponseModel?> GetUserTweetTimeLineAsync(string userId, Dictionary<string, string> paramas)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId));

        if (!await _authenticationService.GenerateAccessTokenAsync())
            throw new ArgumentNullException("unable to generate twitter token");

        //add total tweet count
        paramas = AddMaxResultIntoDictionary(paramas);

        var url = _twitterUrlService.GetUserTweetTimeLineUrl(userId, paramas);

        HttpClient client = _authenticationService.GetAuthorizedClient();

        var httpResponse = await client.GetAsync(url);

        if (!httpResponse.IsSuccessStatusCode)
            return null;

        return await httpResponse.ParseResponseData<TimeLineResponseModel>();
    }

    private Dictionary<string, string> AddMaxResultIntoDictionary(Dictionary<string, string> dictionary)
    {
        if (dictionary is null)
            dictionary = new Dictionary<string, string>();
        if (!dictionary.ContainsKey(RequestFields.MaxResults))
        {
            dictionary.Add(RequestFields.MaxResults, _userService.GetMaxResultForQuery());
        }
        return dictionary;
    }
}
