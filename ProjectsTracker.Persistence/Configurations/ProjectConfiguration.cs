using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasOne(e => e.ProjectManager)
                .WithMany();

            builder
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects);
        }
    }
}
