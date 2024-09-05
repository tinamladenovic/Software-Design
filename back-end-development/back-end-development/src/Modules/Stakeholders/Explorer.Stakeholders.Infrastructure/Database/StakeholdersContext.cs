using Explorer.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace Explorer.Stakeholders.Infrastructure.Database;

public class StakeholdersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<RequestToJoinClub> RequestsToJoinClub { get; set; }
    public DbSet<ClubRequest> ClubRequests { get; set; }
    public DbSet<ClubUsers> ClubUsers { get; set; }
    public DbSet<TouristNote> TouristNote { get; set; } 
    public DbSet<ApplicationRate> ApplicationRate{ get; set; }
    public DbSet<Followers> Followers { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("stakeholders");

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

        ConfigureStakeholder(modelBuilder);
    }

    private static void ConfigureStakeholder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Person>(s => s.UserId);

        modelBuilder.Entity<RequestToJoinClub>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<RequestToJoinClub>(r => r.TouristId);

        modelBuilder.Entity<User>()
           .HasMany<RequestToJoinClub>()
           .WithOne()
           .HasForeignKey(r => r.TouristId)
           .IsRequired();

        modelBuilder.Entity<RequestToJoinClub>()
            .HasIndex(r => new { r.TouristId, r.TouristClubId })
            .IsUnique();
       
        modelBuilder.Entity<User>()
            .HasMany<ClubRequest>()
            .WithOne()
            .HasForeignKey(e => e.TouristId)
            .IsRequired();

        modelBuilder.Entity<User>()
           .HasMany<ClubUsers>()
           .WithOne()
           .HasForeignKey(e => e.TouristId)
           .IsRequired();       
           
        modelBuilder.Entity<ApplicationRate>()
            .HasOne(ap => ap.Person)
            .WithOne(p => p.ApplicationRate)
            .HasForeignKey<ApplicationRate>(ap => ap.PersonId)
            .IsRequired();

        modelBuilder.Entity<User>()
           .HasMany<Notification>()
           .WithOne()
           .HasForeignKey(n => n.SenderId)
           .IsRequired();

        modelBuilder.Entity<User>()
           .HasMany<Notification>()
           .WithOne()
           .HasForeignKey(n => n.ReceiverId)
           .IsRequired();

        modelBuilder.Entity<User>()
           .HasMany<Followers>()
           .WithOne()
           .HasForeignKey(f => f.FollowedId)
           .IsRequired();

        modelBuilder.Entity<User>()
           .HasMany<Followers>()
           .WithOne()
           .HasForeignKey(f => f.FollowingId)
           .IsRequired();

        modelBuilder.Entity<Followers>()
            .HasIndex(f => new { f.FollowedId, f.FollowingId })
            .IsUnique();
    }
}