using Icrats.KMS.DAL.Configurations;
using Icrats.KMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrats.KMS.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Lock> Locks { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<CustodianType> CustodianTypes { get; set; }
        public DbSet<DoorType> DoorTypes { get; set; }
        public DbSet<Custodian> Custodians { get; set; }

        // Configuring relationships and other properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships
            modelBuilder.Entity<Facility>()
                .HasMany(f => f.Doors)
                .WithOne(d => d.Facility)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);  // If a facility is deleted, its doors will be deleted as well

            modelBuilder.Entity<Door>()
                .HasOne(d => d.DoorType)
                .WithMany(dt => dt.Doors)
                .HasForeignKey(d => d.DoorTypeId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevents deletion of DoorType if it has related doors

            modelBuilder.Entity<Door>()
                .HasMany(d => d.Locks)
                .WithOne(l => l.Door)
                .HasForeignKey(l => l.DoorId)
                .OnDelete(DeleteBehavior.Cascade);  // Deleting a door will delete its related locks

            modelBuilder.Entity<Lock>()
                .HasMany(l => l.Keys)
                .WithOne(k => k.Lock)
                .HasForeignKey(k => k.LockId)
                .OnDelete(DeleteBehavior.Cascade);  // Deleting a lock will delete its related keys

            // Configuring the Key-SpareKey mapping table
            modelBuilder.Entity<KeySpareKeyMap>()
                .HasOne(k => k.Key) // Original key
                .WithMany() // No navigation property back to KeySpareKeyMap
                .HasForeignKey(k => k.KeyId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if the original key is deleted

            modelBuilder.Entity<KeySpareKeyMap>()
                .HasOne(k => k.SpareKey) // Spare key
                .WithMany() // No navigation property back to KeySpareKeyMap
                .HasForeignKey(k => k.SpareKeyId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if the spare key is deleted

            // Custodian relationships
            modelBuilder.Entity<Custodian>()
                .HasOne(c => c.User)
                .WithMany()  // Assuming User doesn't need to have navigation property back to Custodian
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if user is deleted

            modelBuilder.Entity<Custodian>()
                .HasOne(c => c.CustodianType)
                .WithMany()  // Assuming CustodianType doesn't need to have navigation property back to Custodian
                .HasForeignKey(c => c.CustodianTypeId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of CustodianType if there are custodians associated

            // Ensuring that the CustodianTypeName is unique
            modelBuilder.Entity<CustodianType>()
                .HasIndex(c => c.CustodianTypeName)
                .IsUnique();  // Ensures custodian type names are unique

            // Ensuring that the DoorTypeName is unique
            modelBuilder.Entity<DoorType>()
               .HasIndex(dt => dt.DoorTypeName)
               .IsUnique();  // Ensures door type names are unique
        }
    }
}
