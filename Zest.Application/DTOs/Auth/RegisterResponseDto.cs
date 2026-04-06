

namespace Zest.Application.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string? Email { get; set; } = string.Empty;
    }
}
