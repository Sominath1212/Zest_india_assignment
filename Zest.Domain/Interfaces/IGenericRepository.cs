using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zest.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void UpdatePatch(T entity);

        Task<int> CountAsync();
    }
}
