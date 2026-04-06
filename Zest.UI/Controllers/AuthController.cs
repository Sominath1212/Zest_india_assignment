using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zest.Application.DTOs.Auth;
using Zest.Application.Interfaces;

namespace Zest.UI.Controllers;


/// <summary>
/// Handles all the authentication .
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Register Route for the register user.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        RegisterResponseDto? token = await _authService.Register(dto);
        return Ok(new { token });
    }


    /// <summary>
    /// Login route for login.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        LoginResponseDto? token = await _authService.Login(dto);
        return Ok(new { token });
    }
}