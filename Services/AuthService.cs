using BookApp.DTOs;
using BookApp.Entities;
using BookApp.Repositories.Interfaces;
using BookApp.Services.Interfaces;

namespace BookApp.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
     public async Task RegisterAsync(RegisterRequest request)
     {
          var existingUser = await userRepository.GetByEmailAsync(request.Email);
          if (existingUser != null)
          {
               throw new Exception("Email already exists");
          }
          
          var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

          var user = new User
          {
               Email = request.Email,
               PasswordHash = passwordHash,
          };
          
          await userRepository.AddAsync(user);
     }
}