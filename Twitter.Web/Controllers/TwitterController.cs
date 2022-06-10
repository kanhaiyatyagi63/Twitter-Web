using Microsoft.AspNetCore.Mvc;
using Twitter.Services;

namespace Twitter.Web.Controllers
{
    public class TwitterController : Controller
    {
        private readonly ILogger<TwitterController> _logger;
        private readonly ITwitterWorkerService _twitterWorkerService;

        public TwitterController(ILogger<TwitterController> logger,
                              ITwitterWorkerService twitterWorkerService)
        {
            _logger = logger;
            _twitterWorkerService = twitterWorkerService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _twitterWorkerService.UserService.GetUserByUsernameAsync("Kanhaiyatyagi63", new Dictionary<string, string>()
            {
                //{ RequestFields.UserFields , $"{UserFields.Id},{UserFields.Username},{UserFields.Entities},{UserFields.Entities},{UserFields.Url}" },
                //{  RequestFields.TweetFields, $"{TweetFields.Attachments},{TweetFields.Entities}"}
            });
            if (user is not null) { 
            
            }
            return View();
        }
    }
}
