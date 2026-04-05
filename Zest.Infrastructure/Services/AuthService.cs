using Microsoft.Extensions.Logging;
using Zest.Application.DTOs.Auth;
using Zest.Application.Interfaces;
using Zest.Domain.Entities;
using Zest.Domain.Interfaces;

namespace Zest.Infrastructure.Services;

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

    public async Task<string> Register(RegisterRequestDto dto)
    {
        _logger.LogInformation("Register attempt for email {Email}", dto.Email);

        var exists = await _authRepository.IsEmailExistsAsync(dto.Email);
        if (exists)
        {
            _logger.LogWarning("Register failed. Email already exists: {Email}", dto.Email);
            throw new Exception("User already exists");
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            
        };

        await _authRepository.RegisterAsync(user);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("User registered successfully: {Email}", dto.Email);

        return _jwtService.GenerateToken(user.Id.ToString(), user.Email);
    }

    public async Task<string> Login(LoginRequestDto dto)
    {
        _logger.LogInformation("Login attempt for email {Email}", dto.Email);

        var user = await _authRepository.GetByEmailAsync(dto.Email);
        if (user is null)
        {
            _logger.LogWarning("Login failed. User not found: {Email}", dto.Email);
            throw new Exception("Invalid credentials");
        }

        var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!isValid)
        {
            _logger.LogWarning("Login failed. Invalid password for: {Email}", dto.Email);
            throw new Exception("Invalid credentials");
        }

        _logger.LogInformation("Login successful for email {Email}", dto.Email);

        return _jwtService.GenerateToken(user.Id.ToString(), user.Email);
    }
}