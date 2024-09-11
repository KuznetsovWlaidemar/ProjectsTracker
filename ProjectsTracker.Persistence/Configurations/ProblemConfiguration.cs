using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsTracker.Domain.Models;
using System.Reflection.Emit;

namespace ProjectsTracker.Persistence.Configurations
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasOne(p => p.Author)
                   .WithMany();

            builder.HasOne(p => p.Assignee)
                   .WithMany();
        }

    }
}
