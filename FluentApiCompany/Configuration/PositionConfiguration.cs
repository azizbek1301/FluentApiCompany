using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiCompany.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.Property(x=>x.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Positions);

            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Position);
        }
    }
}
