using BookApp.DTOs;
using BookApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        await authService.RegisterAsync(request);
        return Ok();
    }
    
}