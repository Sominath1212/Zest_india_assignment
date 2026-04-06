

using Zest.Application.DTOs.Auth;

namespace Zest.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto dto);
        Task<RegisterResponseDto> Register(RegisterRequestDto dto);
    }
}
