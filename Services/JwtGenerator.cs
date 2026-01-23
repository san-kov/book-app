using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookApp.Entities;
using BookApp.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BookApp.Services;

public class JwtGenerator(IConfiguration configuration) : IJwtGenerator
{
    public string GenerateToken(User user)
    {
        var jwtSettings = configuration.GetSection("jwt");
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiresMinutes"]!)),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}