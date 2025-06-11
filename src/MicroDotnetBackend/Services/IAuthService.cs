using MicroDotnetBackend.Models;

namespace MicroDotnetBackend.Services;

public interface IAuthService
{
    Task<(bool success, string token)> ValidateUserAsync(LoginRequest request);
} 