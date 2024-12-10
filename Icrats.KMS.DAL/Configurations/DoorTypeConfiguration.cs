using Icrats.KMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrats.KMS.DAL.Configurations
{
    public class DoorTypeConfiguration : IEntityTypeConfiguration<DoorType>
    {
        public DoorTypeConfiguration() { }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DoorType> builder)
        {
            // Set table name
            builder.ToTable("DoorTypes");
            // Primary Key
            builder.HasKey(dt => dt.DoorTypeId);
            // Properties
            builder.Property(dt => dt.DoorTypeName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(dt => dt.DoorTypeDescription)
                .HasMaxLength(500);

            // Relationships
            builder.HasMany(dt => dt.Doors)
                .WithOne(d => d.DoorType)
                .HasForeignKey(d => d.DoorTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
