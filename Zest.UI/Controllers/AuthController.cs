using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zest.Application.DTOs.Auth;
using Zest.Application.Interfaces;

namespace Zest.UI.Controllers;

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
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var token = await _authService.Register(dto);
        return Ok(new { token });
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var token = await _authService.Login(dto);
        return Ok(new { token });
    }
}