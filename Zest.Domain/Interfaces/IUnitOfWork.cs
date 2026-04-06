namespace Zest.Domain.Interfaces
{

    /// <summary>
    /// unit of work interface for the unit of work.
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// Class for the repository pattern, which provides a generic repository for the specified .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// saves a changes.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
