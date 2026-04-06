namespace Zest.Application.DTOs.Auth
{
    /// <summary>
    /// Represents the response returned after a user registration attempt.
    /// </summary>
    /// <remarks>This data transfer object contains information about the outcome of a registration operation,
    /// including success status, a descriptive message, the assigned user identifier, and the registered email address.
    /// All properties are nullable to accommodate partial or failed registration scenarios.</remarks>
    public class RegisterResponseDto
    {
      /// <summary>
      /// Gets or sets a value indicating whether the operation completed successfully.
      /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string? Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the user associated with this entity.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string? Email { get; set; } = string.Empty;
    }
}
