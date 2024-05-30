using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Tashgheel_Api.Services;
public interface ILinkedInService
{
    Task<string> GetAccessToken(string code);
    Task<LinkedInProfile> GetProfile(string accessToken);
}

public class LinkedInService : ILinkedInService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public LinkedInService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    

    public async Task<string> GetAccessToken(string code)
    {
        var tokenResponse = await _httpClient.PostAsync("https://www.linkedin.com/oauth/v2/accessToken", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "redirect_uri", _configuration["LinkedIn:RedirectUri"] },
            { "client_id", _configuration["LinkedIn:ClientId"] },
            { "client_secret", _configuration["LinkedIn:ClientSecret"] }
        }));

        var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
        var token = JsonConvert.DeserializeObject<LinkedInToken>(tokenContent);
        

        return token.AccessToken;
    }

    public async Task<LinkedInProfile> GetProfile(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var profileResponse = await _httpClient.GetAsync("https://api.linkedin.com/v2/me");

        var profileContent = await profileResponse.Content.ReadAsStringAsync();
        var profile = JsonConvert.DeserializeObject<LinkedInProfile>(profileContent);

        return profile;
    }
}

