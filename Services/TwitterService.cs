using Tweetinvi;
using Tweetinvi.Core.Models;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Tashgheel_Api.Services;

public interface ITwitterService
{
    Task<IEnumerable<ITweet>> GetLatestTweets(string username, int count = 10);
}


public class TwitterService : ITwitterService
{

    private readonly string _consumerKey;
    private readonly string _consumerSecret;
    private readonly string _accessToken;
    private readonly string _accessTokenSecret;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly TwitterClient _client;

    public TwitterService(IConfiguration configuration)
    {
        _consumerKey = "bgQmBjHSooZHkzThHktkcHJPu";
        _consumerSecret = "THAUfG6eCFHxOOejaSwsc8OH0Pvo7j3NW5xzDHDaMX6O92zPfA";
        _accessToken = "2998213104-IhHFFExnYQx6MiBL9d74SOnXMdASLf3I8xH9QbB";
        _accessTokenSecret = "oUvi9KZ1Fea3Gzji5CCKyVAytyFO32Gr2n951SlATNXVx";
        

        _client = new TwitterClient(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
    }
   

    public async Task<IEnumerable<ITweet>> GetLatestTweets(string username, int count = 2)
    {
        var user = await _client.Users.GetUserAsync(username);
        var userTimelineParameters = new GetUserTimelineParameters(user)
        {
            PageSize = count
        };

        return await _client.Timelines.GetUserTimelineAsync(userTimelineParameters);
    }
}