using Microsoft.AspNetCore.Mvc;
using MicroDotnetBackend.Models;
using MicroDotnetBackend.Services;

namespace MicroDotnetBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var (success, token) = await _authService.ValidateUserAsync(request);
            
            if (success)
            {
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login attempt");
            return StatusCode(500, new { message = "An error occurred during login" });
        }
    }
} 