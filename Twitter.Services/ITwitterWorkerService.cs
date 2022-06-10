using Twitter.Services.Services.Abstractions;

namespace Twitter.Services;
public interface ITwitterWorkerService
{
    public IAuthenticationService AuthenticationService { get; }
    public IUserService UserService { get; }
    public ITwitterUrlService TwitterUrlService { get; }
    public ITimeLineService TimeLineService { get; }
}
