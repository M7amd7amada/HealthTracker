using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HealthTracker.Data.Data;

public class AppDbContext : IdentityDbContext
{
    public virtual new DbSet<User>? Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}