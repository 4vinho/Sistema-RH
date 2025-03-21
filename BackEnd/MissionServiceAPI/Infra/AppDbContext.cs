using Microsoft.EntityFrameworkCore;

namespace MissionServiceAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Mission> Mission { get; set; }
}
