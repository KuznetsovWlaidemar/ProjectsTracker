using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Domain;

namespace ProjectsTracker
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Fields

        private readonly IConfiguration _configuration;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion

        #region Methods
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Role);

            modelBuilder.Entity<Employee>()
                .HasMany(h => h.Projects)
                .WithMany(w => w.Employees);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ProjectsTrackerDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        #endregion
    }
}
