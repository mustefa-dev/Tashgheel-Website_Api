using System.Net;
using Newtonsoft.Json.Linq;

namespace Tashgheel_Api.Services;
public interface IFacebookService
{
    Task<JArray> GetLatestFacebookPosts(int numberOfPosts);
    Task<JArray> GetPublicPagePosts(string publicPageUsername, int numberOfPosts);

}

public class FacebookService : IFacebookService
{
    private string appId = "1811255455964887";
    private string appSecret = "00d3665aaa7a0e275054b6bc186b1159";
    private string pageId = "20531316728";

    public async Task<JArray> GetLatestFacebookPosts(int numberOfPosts)
    {
        var json = string.Empty;
        var url = $"https://graph.facebook.com/{pageId}/posts?limit={numberOfPosts}&access_token={appId}|{appSecret}";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            Console.WriteLine(response.Content.ToString());
        }

        var jsonObject = JObject.Parse(json);
        return (JArray)jsonObject["data"]?? new JArray();
    }
    public async Task<JArray> GetPublicPagePosts(string publicPageUsername, int numberOfPosts = 5)
    {
        var url = $"https://graph.facebook.com/{publicPageUsername}/posts?limit={numberOfPosts}";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(json);
            return (JArray)jsonObject["data"] ?? new JArray();
        }
    }
    
}