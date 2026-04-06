
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zest.Domain.Entities
{
    public class Student
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
