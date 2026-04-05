using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zest.Application.DTOs.Student;

namespace Zest.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDto> CreateAsync(CreateStudentRequestDto request);
        Task<StudentResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<StudentResponseDto>> GetAllAsync();
        Task<StudentResponseDto?> UpdateAsync(UpdateStudentRequestDto request);
        Task<bool> DeleteAsync(int id);

    }
}
