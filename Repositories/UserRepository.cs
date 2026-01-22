using BookApp.Data;
using BookApp.Entities;
using BookApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Repositories;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
    }
}