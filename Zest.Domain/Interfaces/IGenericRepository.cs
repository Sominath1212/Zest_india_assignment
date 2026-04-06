namespace Zest.Domain.Interfaces
{
    /// <summary>
    /// Generic repository interface that defines common data access methods for entities of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets an entity by its unique identifier asynchronously. =
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all entities of type T asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets a paged list of entities.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);


        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Update an existing entity.
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity.
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Partially update an entities.
        /// </summary>
        /// <param name="entity"></param>
        void UpdatePatch(T entity);

        /// <summary>
        /// Gets a Count of the entities.
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
    }
}
