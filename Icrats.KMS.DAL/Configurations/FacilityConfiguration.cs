using Icrats.KMS.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Icrats.KMS.DAL.Configurations
{
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            // Set table name
            builder.ToTable("Facilities");

            // Primary Key
            builder.HasKey(f => f.FacilityId);

            // Properties
            builder.Property(f => f.FacilityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.FacilityAddress)
                .HasMaxLength(200);

            builder.Property(f => f.FacilityLocation)
                .HasMaxLength(50);

            // Relationships
            builder.HasMany(f => f.Doors)
                .WithOne(d => d.Facility)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
