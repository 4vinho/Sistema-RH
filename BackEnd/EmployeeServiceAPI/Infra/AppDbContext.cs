using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employee { get; set; }
}
