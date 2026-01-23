using BookApp.DTOs;
using BookApp.Entities;
using BookApp.Exceptions;
using BookApp.Repositories.Interfaces;
using BookApp.Services.Interfaces;

namespace BookApp.Services;

public class AuthService(IUserRepository userRepository, IJwtGenerator jwtGenerator) : IAuthService
{
     public async Task RegisterAsync(RegisterRequest request)
     {
          var existingUser = await userRepository.GetByEmailAsync(request.Email);
          if (existingUser != null)
          {
               throw new AuthException("Email already exists");
          }
          
          var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

          var user = new User
          {
               Email = request.Email,
               PasswordHash = passwordHash,
          };
          
          await userRepository.AddAsync(user);
     }

     public async Task<AuthResponse> LoginAsync(LoginRequest request)
     {
          var user = await userRepository.GetByEmailAsync(request.Email);
          
          if (user == null) throw new AuthException("Invalid credentials");

          var validPassword = BCrypt.Net.BCrypt.Verify(
               request.Password,
               user.PasswordHash
          );

          if (!validPassword)
          {
               throw new AuthException("Invalid credentials");
          }
          
          var token = jwtGenerator.GenerateToken(user);

          return new AuthResponse
          {
               Token = token,
          };
     }
     
     
}