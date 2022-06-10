using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Twitter.Services;
using Twitter.Services.Services.Abstractions;
using Twitter.Web.Models;

namespace Twitter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITwitterWorkerService _twitterWorkerService;
        private readonly ITweetService _tweetService;

        public HomeController(ILogger<HomeController> logger, ITwitterWorkerService twitterWorkerService)
        {
            _logger = logger;
            _twitterWorkerService = twitterWorkerService;
        }

        public async Task<IActionResult> Index()
        {
            var tokenUrl  = _twitterWorkerService.TwitterUrlService.AccessToken();
            var isGenerated = await _twitterWorkerService.AuthenticationService.GenerateAccessToken();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}