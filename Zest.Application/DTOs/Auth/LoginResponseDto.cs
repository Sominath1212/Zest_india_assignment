namespace Zest.Application.DTOs.Auth
{
    /// <summary>
    /// Represents the response returned after a user login attempt, including authentication status, user information,
    /// and an access token.
    /// </summary>
    /// <remarks>This data transfer object is typically used to convey the outcome of a login operation from
    /// an authentication service to a client application. It includes information about whether the login was
    /// successful, a message describing the result, the user's unique identifier, email address, and a token for
    /// authenticated access to protected resources.</remarks>
    public class LoginResponseDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation completed successfully.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the authentication token used for accessing protected resources.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}