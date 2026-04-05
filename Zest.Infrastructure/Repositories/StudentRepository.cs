using Microsoft.EntityFrameworkCore;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;
using Zest.Infrastructure.Data;

namespace Zest.Infrastructure.Repositories
{
    
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null) return;

            _context.Students.Remove(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            var exists = await _context.Students.AnyAsync(x => x.Id == student.Id);
            if (!exists) return;

            _context.Students.Update(student);
        }
    }
}
