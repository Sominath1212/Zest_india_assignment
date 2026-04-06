using System.ComponentModel.DataAnnotations;
namespace Zest.Domain.Entities
{
    /// <summary>
    /// Represents a student entity with properties.
    /// </summary>
    public class Student
    {

        /// <summary>
        /// Gets or sets the identifier for the student.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        /// <summary>
        /// Gets or set email.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }


        /// <summary>
        /// Gets or sets age.
        /// </summary>
        [Range(1, 120)]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the student record was created.
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
