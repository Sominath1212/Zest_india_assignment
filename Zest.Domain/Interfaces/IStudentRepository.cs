
using Zest.Domain.Entities;

namespace Zest.Domain.Interfaces
{

    /// <summary>
    /// Student repository interface.
    public interface IStudentRepository
    {
        /// <summary>
        /// Add new student to the repository.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task AddStudentAsync(Student student);

        /// <summary>
        ///  Gets a student by their unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Student> GetStudentByIdAsync(int id);

        /// <summary>
        /// Gets all Students.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        /// <summary>
        /// Update an existing students 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task UpdateStudentAsync(Student student);

        /// <summary>
        /// Deletes an student.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteStudentAsync(int id);
    }
}
