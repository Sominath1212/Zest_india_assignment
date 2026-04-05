
using Zest.Domain.Entities;

namespace Zest.Domain.Interfaces
{
   public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
    }
}
