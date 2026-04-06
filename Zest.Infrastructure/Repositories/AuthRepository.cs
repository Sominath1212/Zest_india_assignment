using Microsoft.EntityFrameworkCore;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;
using Zest.Infrastructure.Data;

namespace Zest.Infrastructure.Repositories
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class AuthRepository :IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(x => x.Email == email);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
