namespace Zest.Application.DTOs.Student
{
    /// <summary>
    /// Represents the data required to update an existing student record.
    /// </summary>
    /// <remarks>This data transfer object is typically used in update operations where only the specified
    /// fields are modified. Properties that are null will not be updated. All properties are optional, allowing for
    /// partial updates.</remarks>
    public class UpdateStudentRequestDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address associated with the entity.
        /// </summary>

        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age value.
        /// </summary>

        public int? Age { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string? CourseName { get; set; } = string.Empty;
    }
}
