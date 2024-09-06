using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
