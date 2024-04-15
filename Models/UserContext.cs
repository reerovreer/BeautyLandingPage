using Microsoft.EntityFrameworkCore;

namespace LandingPage.Models;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public UserContext(DbContextOptions<UserContext> options) : base(options){}
}

