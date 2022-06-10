﻿using Twitter.Services.Extensions;
using Twitter.Services.Models.ResponseModels.Users;
using Twitter.Services.Services.Abstractions;
using Twitter.Services.Utilities;

namespace Twitter.Services.Services;
public class UserService : IUserService
{
    public UserService(ITwitterUrlService twitterUrlService, IAuthenticationService authenticationService)
    {
        _twitterUrlService = twitterUrlService;
        _authenticationService = authenticationService;
    }

    public ITwitterUrlService _twitterUrlService { get; }
    public IAuthenticationService _authenticationService { get; }

    public async Task<UserResponseModel?> GetUserByUsernameAsync(string username, Dictionary<string, string> paramas)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentNullException(nameof(username));
        if (!await _authenticationService.GenerateAccessTokenAsync())
            throw new ArgumentNullException("unable to generate twitter token");

        var url = string.Empty;
        if (paramas is null || !paramas.Any())
            url = _twitterUrlService.GetUserByUserNameUrl(username);
        else
        {
            var queryParamas = Utility.GetQueryParams(paramas);
            url = _twitterUrlService.GetUserByUserNameUrl(username, queryParamas);
        }

        HttpClient client = _authenticationService.GetAuthorizedClient();

        var httpResponse = await client.GetAsync(url);

        if (!httpResponse.IsSuccessStatusCode)
            return null;

        return await httpResponse.ParseResponseData<UserResponseModel>();
    }

}

