using Microsoft.Extensions.Logging;
using Zest.Application.Commons.Constants;
using Zest.Application.DTOs.Auth;
using Zest.Application.Interfaces;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;

namespace Zest.Infrastructure.Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTService _jwtService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IAuthRepository authRepository,
            IUnitOfWork unitOfWork,
            IJWTService jwtService,
            ILogger<AuthService> logger)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<RegisterResponseDto> Register(RegisterRequestDto dto)
        {
            _logger.LogInformation("Register attempt for email {Email}", dto.Email);

            bool exists = await _authRepository.IsEmailExistsAsync(dto.Email);
            if (exists)
            {
                _logger.LogWarning("Register failed. Email already exists: {Email}", dto.Email);

                return new RegisterResponseDto
                {
                    IsSuccess = false,
                    Message = Constants.UserAlreadyPresent,
                };
            }

            User user = new User
            {

                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),

            };

            await _authRepository.RegisterAsync(user);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User registered successfully: {Email}", dto.Email);



            return new RegisterResponseDto
            {
                IsSuccess = true,
                Message = Constants.UserRegisteredMessage,
                UserId = user.Id,
                Email = user.Email
            };
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            _logger.LogInformation("Login attempt for email {Email}", dto.Email);

            User? user = await _authRepository.GetByEmailAsync(dto.Email);
            if (user is null)
            {
                _logger.LogWarning("Login failed. User not found: {Email}", dto.Email);

                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = Constants.InvalidCredentialsMessage,
                    Token = null
                };
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isValid)
            {
                _logger.LogWarning("Login failed. Invalid password for: {Email}", dto.Email);
                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = Constants.InvalidCredentialsMessage,
                    Token = null
                };
            }

            _logger.LogInformation("Login successful for email {Email}", dto.Email);
            string token = _jwtService.GenerateToken(user.Id.ToString(), user.Email);

            return new LoginResponseDto
            {
                IsSuccess = true,
                Message = Constants.LoginSuccessMessage,
                Token = token,
                UserId = user.Id,
                Email = user.Email
            };
        }
    }
}