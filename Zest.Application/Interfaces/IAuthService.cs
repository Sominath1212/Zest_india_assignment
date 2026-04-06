using Zest.Application.DTOs.Auth;
namespace Zest.Application.Interfaces
{

    /// <summary>
    /// Defines methods for authenticating users and registering new user accounts.
    /// </summary>
    /// <remarks>Implementations of this interface provide authentication and registration functionality for
    /// user accounts. Methods are asynchronous and return results containing authentication or registration details.
    /// Thread safety and specific authentication mechanisms depend on the implementation.</remarks>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="dto">An object containing the user's login credentials and any additional authentication data required.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a LoginResponseDto with
        /// authentication details if the login is successful.</returns>
        Task<LoginResponseDto> Login(LoginRequestDto dto);

        /// <summary>
        /// Registers a new user account using the specified registration details.
        /// </summary>
        /// <param name="dto">An object containing the user's registration information. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a RegisterResponseDto with the
        /// outcome of the registration attempt.</returns>
        Task<RegisterResponseDto> Register(RegisterRequestDto dto);
    }
}
