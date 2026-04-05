

using Zest.Domain.Entities;

namespace Zest.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> IsEmailExistsAsync(string email);
        Task RegisterAsync(User user);
    }
}
