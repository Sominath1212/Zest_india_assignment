
using System.ComponentModel.DataAnnotations;
namespace Zest.Application.DTOs.Student
{
    public class UpdateStudentRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
    }
}
