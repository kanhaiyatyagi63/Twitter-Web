using Twitter.Services.Models.ResponseModels.Users;

namespace Twitter.Services.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserResponseModel?> GetUserByUsernameAsync(string username, Dictionary<string, string> paramas);
    }
}
