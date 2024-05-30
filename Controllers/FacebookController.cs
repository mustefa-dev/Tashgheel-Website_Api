using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacebookController : ControllerBase
{
    private readonly IFacebookService _facebookService;

    public FacebookController(IFacebookService facebookService)
    {
        _facebookService = facebookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLatestPosts(int numberOfPosts = 5)
    {
        var posts = await _facebookService.GetLatestFacebookPosts(numberOfPosts);
        return Ok(posts);
    }

    [HttpGet("public/facebook")]
    public async Task<IActionResult> GetFacebookPosts()
    {
        var posts = await _facebookService.GetPublicPagePosts("facebook", 5);
        return Ok(posts);
    
    }
}
