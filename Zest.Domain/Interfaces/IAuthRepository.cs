
using Zest.Domain.Entities;
namespace Zest.Domain.Interfaces
{
    /// <summary>
    /// Authentication repository interface.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Gets a user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Checks if a user with the specified email already exists in the system.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsEmailExistsAsync(string email);

        /// <summary>
        /// Registers a new user in the system. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterAsync(User user);
    }
}
