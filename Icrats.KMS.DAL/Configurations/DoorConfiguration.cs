using Icrats.KMS.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrats.KMS.DAL.Configurations
{
    public class DoorConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            // Set table name
            builder.ToTable("Doors");

            // Primary Key
            builder.HasKey(d => d.DoorId);

            // Properties
            builder.Property(d => d.DoorCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.DoorDescription)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(d => d.Facility)
                .WithMany(f => f.Doors)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.DoorType)
                .WithMany(dt => dt.Doors)
                .HasForeignKey(d => d.DoorTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
