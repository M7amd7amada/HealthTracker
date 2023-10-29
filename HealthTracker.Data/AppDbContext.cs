using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HealthTracker.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}