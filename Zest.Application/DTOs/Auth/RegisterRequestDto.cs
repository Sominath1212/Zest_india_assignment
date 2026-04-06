using System.ComponentModel.DataAnnotations;

namespace Zest.Application.DTOs.Auth
{
    /// <summary>
    /// Represents the data required to register a new user account.
    /// </summary>
    /// <remarks>This data transfer object is typically used as input for user registration endpoints. All
    /// properties are required and must be provided with valid values.</remarks>
    public class RegisterRequestDto
    {
        /// <summary>
        /// Gets or sets the name associated with the entity.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password associated with the user or entity.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

    }
}