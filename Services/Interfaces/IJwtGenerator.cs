using BookApp.Entities;

namespace BookApp.Services.Interfaces;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}