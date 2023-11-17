using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiCompany.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(x=>x.Surname)
                .HasMaxLength (30)
                .IsRequired();

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Employees);
        }
    }
}
