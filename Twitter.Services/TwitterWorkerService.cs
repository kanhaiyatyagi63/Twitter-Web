using Twitter.Services.Services.Abstractions;

namespace Twitter.Services
{
    public class TwitterWorkerService : ITwitterWorkerService
    {
        public IAuthenticationService AuthenticationService { get; }
        public IUserService UserService { get; }
        public ITwitterUrlService TwitterUrlService { get; }

        public TwitterWorkerService(IAuthenticationService authenticationService,
                                    IUserService userService, 
                                    ITwitterUrlService twitterUrlService)
        {
            AuthenticationService = authenticationService;
            UserService = userService;
            TwitterUrlService = twitterUrlService;
        }
    }
}
