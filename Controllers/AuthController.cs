using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.DATA.DTOs.User;
using Tashgheel_Api.Services;
using Tashgheel_Api.Utils;

namespace Tashgheel_Api.Controllers;
//[Authorize(Roles = "Admin")]

public class UsersController : BaseController{
    private readonly IUserService _userService;
    private readonly ILinkedInService _linkedInService;

    public UsersController(IUserService userService, ILinkedInService linkedInService)
    {
        _userService = userService;
        _linkedInService = linkedInService;
    }
    [AllowAnonymous]

    [HttpPost("/api/Login")]
    public async Task<ActionResult> Login(LoginForm loginForm) => Ok(await _userService.Login(loginForm));
    
    [AllowAnonymous]

    [HttpPost("/api/Users")]
    public async Task<ActionResult> Create(RegisterForm registerForm) =>
        Ok(await _userService.Register(registerForm));


    [HttpGet("/api/Users/{id}")]
    public async Task<ActionResult> GetById(Guid id) => OkObject(await _userService.GetUserById(id));

    [HttpPut("/api/Users/{id}")]
    public async Task<ActionResult> Update(UpdateUserForm updateUserForm, Guid id) =>
        Ok(await _userService.UpdateUser(updateUserForm, id));

    [HttpDelete("/api/Users/{id}")]
    public async Task<ActionResult> Delete(Guid id) => Ok(await _userService.DeleteUser(id));


    [HttpGet("/api/Users")]
    public async Task<ActionResult<Respons<UserDto>>> GetAll([FromQuery] UserFilter filter) =>
        Ok(await _userService.GetAll(filter), filter.PageNumber, filter.PageSize);
 
}