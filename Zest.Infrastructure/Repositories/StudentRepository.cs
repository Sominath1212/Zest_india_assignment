using Microsoft.EntityFrameworkCore;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;
using Zest.Infrastructure.Data;

namespace Zest.Infrastructure.Repositories
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task DeleteStudentAsync(int id)
        {
            Student? student = await _context.Students.FindAsync(id);
            if (student is null) return;

            _context.Students.Remove(student);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task UpdateStudentAsync(Student student)
        {
            bool exists = await _context.Students.AnyAsync(x => x.Id == student.Id);
            if (!exists) return;

            _context.Students.Update(student);
        }
    }
}
