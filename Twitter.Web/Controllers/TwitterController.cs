using Microsoft.AspNetCore.Mvc;
using Twitter.Services;
using Twitter.Services.Constants;
using Twitter.Services.Utilities;

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
        public async Task<IActionResult> IndexAsync(string? Username, DateTime? StartDate, DateTime? EndDate)
        {
            if (string.IsNullOrEmpty(Username))
            {
                ViewBag.error = "username is required";
                return View();
            }

            if (StartDate.HasValue && !EndDate.HasValue)
            {
                ViewBag.error = "end date is required";
                return View();
            }
            if (!StartDate.HasValue && EndDate.HasValue)
            {
                ViewBag.error = "start date is required";
                return View();
            }
            ViewBag.Username = Username;



            var user = await _twitterWorkerService.UserService.GetUserByUsernameAsync(Username, new Dictionary<string, string>());

            if (user is not null && user.Data is not null && !string.IsNullOrEmpty(user.Data.Id))
            {
                var dictionary = new Dictionary<string, string>();
                //default paramas
                dictionary.Add(RequestFields.TweetFields, $"{TweetFields.AuthorId},{TweetFields.CreatedAt},{TweetFields.Lang},{TweetFields.Source},{TweetFields.ContextAnnotations},{TweetFields.Entities}");
                dictionary.Add(RequestFields.Exclude, $"{ExcludeFields.Retweets},{ExcludeFields.Replies}");
                // custom from query
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    ViewBag.StartDate = StartDate.Value.ToString("dd/MM/yyyy");
                    ViewBag.EndDate = EndDate.Value.ToString("dd/MM/yyyy");
                    dictionary.Add(RequestFields.StartTime, StartDate.Value.ToRfc3339String());
                    dictionary.Add(RequestFields.EndTime, EndDate.Value.ToRfc3339String());
                }

                var response = await _twitterWorkerService.TimeLineService.GetUserTweetTimeLineAsync(user.Data.Id, dictionary);
                if (response is null)
                {
                    ViewBag.error = "something went wrong. try again later!";
                }
                return View(response);

            }
            else
            {
                ViewBag.error = "something went wrong. try again later!";
            }
            return View();
        }
    }
}
