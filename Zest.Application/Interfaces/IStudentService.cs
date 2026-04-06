using Zest.Application.DTOs.Student;
namespace Zest.Application.Interfaces
{
    /// <summary>
    /// Defines methods for managing student records, including creating, retrieving, updating, and deleting student
    /// information asynchronously.
    /// </summary>
    /// <remarks>Implementations of this interface should ensure thread safety for concurrent operations. All
    /// methods are asynchronous and return tasks that complete when the corresponding operation finishes. The interface
    /// abstracts the underlying data store, allowing for flexible implementations.</remarks>
    public interface IStudentService
    {
        /// <summary>
        /// Asynchronously creates a new student record based on the specified request data.
        /// </summary>
        /// <param name="request">The request object containing the details of the student to create. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a StudentResponseDto with the
        /// details of the created student.</returns>
        Task<StudentResponseDto> CreateAsync(CreateStudentRequestDto request);

        /// <summary>
        /// Asynchronously retrieves a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to retrieve. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see
        /// cref="StudentResponseDto"/> representing the student if found; otherwise, <see langword="null"/>.</returns>
        Task<StudentResponseDto?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all students asynchronously.
        /// </summary>
        /// <returns>StudentResponseDto</returns>
        Task<IEnumerable<StudentResponseDto>> GetAllAsync();

        /// <summary>
        /// Updates an existing student record with the specified identifier using the provided request data. The update is
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        Task<StudentResponseDto?> PatchAsync(int id, UpdateStudentRequestDto request);

        /// <summary>
        /// Deletes a student record with the specified identifier asynchronously. The method returns a boolean value indicating
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

    }
}
