using Twitter.Services.Models.ResponseModels.TimeLine;

namespace Twitter.Services.Services.Abstractions
{
    public interface ITimeLineService
    {
        Task<TimeLineResponseModel?> GetUserTweetTimeLineAsync(string userId, Dictionary<string, string> paramas);
    }
}
