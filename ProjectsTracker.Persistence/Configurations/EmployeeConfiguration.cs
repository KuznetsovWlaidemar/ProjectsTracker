using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Устанавливаем первичный ключ
            builder.HasKey(e => e.EmployeeId);

            // Конфигурируем отношение Many-to-Many с сущностью Project
            builder
                .HasMany(e => e.Projects)
                .WithMany(p => p.Employees);

            builder.HasIndex(e => e.Email)
                .IsUnique(); // Email уникален
        }
    }
}
