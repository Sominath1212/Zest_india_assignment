

using Zest.Application.DTOs.Auth;

namespace Zest.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginRequestDto dto);
        Task<string> Register(RegisterRequestDto dto);
    }
}
