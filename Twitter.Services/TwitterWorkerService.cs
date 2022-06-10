using Twitter.Services.Services.Abstractions;

namespace Twitter.Services
{
    public class TwitterWorkerService : ITwitterWorkerService
    {
        public IAuthenticationService AuthenticationService { get; }
        public IUserService UserService { get; }
        public ITwitterUrlService TwitterUrlService { get; }
        public ITimeLineService TimeLineService { get; }

        public TwitterWorkerService(IAuthenticationService authenticationService,
                                    IUserService userService,
                                    ITwitterUrlService twitterUrlService,
                                    ITimeLineService timeLineService)
        {
            AuthenticationService = authenticationService;
            UserService = userService;
            TwitterUrlService = twitterUrlService;
            TimeLineService = timeLineService;
        }
    }
}
