namespace Zest.Application.Interfaces
{
    /// <summary>
    /// Defines methods for generating security tokens for user authentication.
    /// </summary>
    public interface IJWTService
    {
        /// <summary>
        /// Generates a security token for the specified user identifier and email address.
        /// </summary>
        /// <param name="userId">The unique identifier of the user for whom the token is generated. Cannot be null or empty.</param>
        /// <param name="email">The email address associated with the user. Cannot be null or empty.</param>
        /// <returns>A string containing the generated security token for the specified user.</returns>
        string GenerateToken(string userId, string email);
    }
}
