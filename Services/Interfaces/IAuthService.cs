using BookApp.DTOs;

namespace BookApp.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequest request);
}