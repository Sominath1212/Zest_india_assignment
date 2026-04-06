using System.ComponentModel.DataAnnotations;

namespace Zest.Application.DTOs.Student
{
    /// <summary>
    /// Represents the data required to create a new student record.
    /// </summary>
    /// <remarks>This data transfer object is typically used as input for APIs or services that register or
    /// add new students. All properties are required and must meet validation constraints such as maximum length, valid
    /// email format, and age range.</remarks>
    public class CreateStudentRequestDto
    {

        /// <summary>
        /// Gets or sets the name associated with the entity.
        /// </summary>
        /// <remarks>The name must be between 2 and 100 characters in length. This property is
        /// required.</remarks>
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age value.
        /// </summary>
        /// <remarks>The valid range for this property is 1 to 120, inclusive. Values outside this range
        /// are not allowed.</remarks>
        [Range(1, 120)]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
    }
}