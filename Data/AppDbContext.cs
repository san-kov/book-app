using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
}