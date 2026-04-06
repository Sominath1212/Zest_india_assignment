using System.ComponentModel.DataAnnotations;

namespace Zest.Domain.Entities
{
    /// <summary>
    /// Represents a User entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or set Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Gets Or sets the name of the user.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password for the user. This property is required and should contain a securely hashed version of the user's password, not the plain text password itself.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }
    }
}