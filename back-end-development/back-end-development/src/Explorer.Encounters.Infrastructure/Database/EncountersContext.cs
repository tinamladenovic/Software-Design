using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Encounters.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database
{
    public class EncountersContext : DbContext
    {
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<EncounterExecution> EncounterExecutions { get; set; }

        public EncountersContext(DbContextOptions<EncountersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("encounters");

            modelBuilder.Entity<Encounter>()
                .Property(e => e.Coordinates)
                .HasColumnType("jsonb");

            modelBuilder.Entity<EncounterExecution>()
                .Property(e => e.LastPosition)
                .HasColumnType("jsonb");
        }
    }
}
