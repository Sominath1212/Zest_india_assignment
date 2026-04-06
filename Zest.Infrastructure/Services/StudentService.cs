
using Zest.Application.DTOs.Student;
using Zest.Application.Interfaces;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;

namespace Zest.Infrastructure.Services
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<StudentResponseDto> CreateAsync(CreateStudentRequestDto request)
        {
            Student entity = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Age = request.Age,
                CourseName = request.CourseName,
                CreateDate = DateTime.UtcNow
            };

            await _repository.AddStudentAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(entity);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            IEnumerable<Student> students = await _repository.GetAllStudentsAsync();
            return students.Select(MapToDto);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            Student? student = await _repository.GetStudentByIdAsync(id);
            if (student is null) return null;

            return MapToDto(student);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<StudentResponseDto?> PatchAsync(int id, UpdateStudentRequestDto request)
        {
            Student? existing = await _repository.GetStudentByIdAsync(id);
            if (existing is null) return null;

            if (!string.IsNullOrWhiteSpace(request.Name))
                existing.Name = request.Name;

            if (!string.IsNullOrWhiteSpace(request.Email))
                existing.Email = request.Email;

            if (request.Age > 0)
                existing.Age = (int)request.Age;

            if (!string.IsNullOrWhiteSpace(request.CourseName))
                existing.CourseName = request.CourseName;

            await _repository.UpdateStudentAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(existing);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            Student? existing = await _repository.GetStudentByIdAsync(id);
            if (existing is null) return false;

            await _repository.DeleteStudentAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        /// <summary>
        /// Prepare result.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static StudentResponseDto MapToDto(Student student)
        {
            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                CourseName = student.CourseName,
                CreateDate = student.CreateDate
            };
        }
    }
}
