using Twitter.Services.Services.Abstractions;

namespace Twitter.Services.Services;
public class TweetService : ITweetService
{
    private readonly ITwitterUrlService _twitterUrlService;
    public TweetService(ITwitterUrlService twitterUrlService)
    {
        _twitterUrlService = twitterUrlService;
    }
}

