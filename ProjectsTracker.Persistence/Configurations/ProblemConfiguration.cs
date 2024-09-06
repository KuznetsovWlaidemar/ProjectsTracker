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
            // Конфигурация для Author (один к одному или многие к одному, если нужно)
            builder.HasOne(p => p.Author)
                   .WithMany() // Если нет обратной навигации от Employee к Problem
                   .HasForeignKey("AuthorId");

            // Конфигурация для Assignee
            builder.HasOne(p => p.Assignee)
                   .WithMany() // Если нет обратной навигации от Employee к Problem
                   .HasForeignKey("AssigneeId");
        }

    }
}
