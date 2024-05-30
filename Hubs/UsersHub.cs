using Microsoft.AspNetCore.SignalR;
using OneSignalApi.Model;
using Tashgheel_Api.DATA.DTOs.GenericDataUpdate;
using Tashgheel_Api.DATA.DTOs.User;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;

public class UsersHub : Hub
{
    public UsersHub()
    {
    }

    public async Task BroadcastUpdatedUserList(List<UserDto> users)
    {
        await Clients.All.SendAsync("UpdatedUserList", users);
    }

    public async Task BroadcastUserEvent( GenericDataUpdateDto<AppUser> user)
    {
        await Clients.All.SendAsync("event", user);
    }
}