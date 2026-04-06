namespace Zest.Application.DTOs.Student
{
    /// <summary>
    /// Represents a data transfer object containing student information for API responses.
    /// </summary>
    /// <remarks>This class is typically used to return student details from service or controller methods in
    /// response to client requests. It encapsulates identifying and descriptive information about a student, such as
    /// their ID, name, email, age, enrolled course, and the date the record was created.</remarks>
    public class StudentResponseDto
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
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age value.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}