using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Domain;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Projects;
using ProjectsTracker.Domain.Problems;

namespace ProjectsTracker
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Fields

        private readonly IConfiguration _configuration;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Problem> Problems { get; set; }

        #endregion

        #region Methods
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employees
            modelBuilder.Entity<Employee>()
                .HasMany(h => h.Projects)
                .WithMany(w => w.Employees);
            #endregion

            #region Projects
            modelBuilder.Entity<Project>()
                .HasOne(h => h.ProjectManager);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ProjectsTrackerDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        #endregion
    }
}
