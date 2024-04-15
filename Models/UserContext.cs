using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LandingPage.Models;

public class UserContext(DbContextOptions<UserContext> options) : IdentityDbContext(options);

