using System.ComponentModel.DataAnnotations;

namespace Zest.Application.DTOs.Auth
{
    /// <summary>
    /// Represents the data required to authenticate a user with an email address and password.
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for authentication.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
