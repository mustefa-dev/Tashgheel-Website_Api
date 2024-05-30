

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.Services;
using Tweetinvi.Models;

namespace Tashgheel_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterController : BaseController
    {
        private readonly ITwitterService _twitterService;

        public TwitterController(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetLatestTweets(string username, int count = 10)
        {
            return  Ok(await _twitterService.GetLatestTweets(username, count));
        }
    }
}