using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers
{
    public class LinkedinController : BaseController
    {
        private readonly ILinkedInService _linkedInService;
        public LinkedinController(ILinkedInService linkedInService)
        {
            _linkedInService = linkedInService;

        }
        /*[HttpGet("signin-linkedin")]
        public IActionResult SignInWithLinkedIn()
        {
            // Generate a new random state and store it in a secure session
            var state = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("State", state);

            var properties = new AuthenticationProperties { RedirectUri = Url.Action("callback"), Items = { { "state", state } } };
            return Challenge(properties, "LinkedIn");
        }

        [HttpGet("signin-linkedin-callback")]
        public async Task<IActionResult> Callback()
        {
            // Read the authentication result
            var authenticateResult = await HttpContext.AuthenticateAsync("LinkedIn");

            if (!authenticateResult.Succeeded)
            {
                // Handle error here
                return BadRequest("Error authenticating with LinkedIn");
            }

            // Verify the state
            var expectedState = HttpContext.Session.GetString("State");
            var actualState = authenticateResult.Properties.Items["state"];
            if (expectedState != actualState)
            {
                // Handle error here
                return BadRequest("Invalid state");
            }

            // Extract the LinkedIn user's profile information
            var linkedinId = authenticateResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var linkedinEmail = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
            var linkedinName = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);

            // TODO: Use the LinkedIn profile information to recognize the user in your application
            // This could involve creating a user in your database, setting a cookie, etc.

            // Redirect the user to a page in your application
            return Redirect("/");
        }*/
        [HttpPost("linkedin-callback")]
        public async Task<ActionResult> LinkedInCallback(string code)
        {
            var accessToken = await _linkedInService.GetAccessToken(code);
            var profile = await _linkedInService.GetProfile(accessToken);
        
            return Ok(profile);
        }

    }
    
}