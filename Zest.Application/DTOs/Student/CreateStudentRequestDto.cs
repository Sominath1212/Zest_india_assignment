using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zest.Application.DTOs.Student
{
    public class CreateStudentRequestDto
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is Required")]
       
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
    }
}
