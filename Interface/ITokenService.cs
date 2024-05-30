using Tashgheel_Api.DATA.DTOs.User;

namespace Tashgheel_Api.Interface
{
    public interface ITokenService
    {
        string CreateToken(TokenDTO user);
    }
}