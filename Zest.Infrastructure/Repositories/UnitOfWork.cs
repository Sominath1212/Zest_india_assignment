using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zest.Domain.Interfaces;
using Zest.Infrastructure.Data;

namespace Zest.Infrastructure.Repositories
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IGenericRepository<T>)_repositories[typeof(T)];

            GenericRepository<T> repo = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repo);

            return repo;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
