using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.EntityFrameworkCore;
using Explorer.Tours.API.Dtos;


namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<TourPreferences> TourPreferences { get; set; }
    public DbSet<TourRating> TourRating { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<TouristClub> TouristClubs { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Checkpoint> Checkpoints { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportComment> ReportComments { get; set; }
    public DbSet<TourReview> TourReview { get; set; }
    public DbSet<FavouriteTour> FavouriteTours { get; set; }
    public DbSet<TourExecution> TourExecutions { get; set; }
    public DbSet<TouristEquipment> TouristEquipment { get; set; }
    public DbSet<TourCoupon> Coupons { get; set; }
    public DbSet<Questionnaire> Questionnaire { get; set; }

    public DbSet<Sale> Sales { get; set; }
    public DbSet<TourSaleConnection> TourSaleConnections { get; set; }
    public DbSet<CompositeTour> CompositeTours { get; set; }

    public DbSet<AnswerDates> AnswerDates { get; set; }

    public ToursContext(DbContextOptions<ToursContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
        modelBuilder.Entity<Checkpoint>().OwnsOne(c => c.Coordinates);
        //ono sto sam dodao na grani
        modelBuilder.Entity<Tour>().Property(item => item.TravelTimeAndMethod).HasColumnType("jsonb");

        modelBuilder.Entity<Tour>()
            .HasMany(t => t.TourEquipment)
            .WithMany(e => e.Tours)
            .UsingEntity(j => j.ToTable("TourEquipment"));

  
        modelBuilder.Entity<Tour>()
            .HasMany(t => t.CompositeTour)
            .WithMany(ct => ct.Tours)
            .UsingEntity(j => j.ToTable("TourCompositeTour"));

        modelBuilder.Entity<FavouriteTour>()
            .HasOne(t => t.Tour)
            .WithMany(t => t.FavouriteTours)
            .HasForeignKey(t => t.TourId)
            .IsRequired();


        modelBuilder.Entity<TourReview>()
            .HasOne(tr => tr.Tour)
            .WithMany(t => t.TourReviews)
            .HasForeignKey(tr => tr.TourId)
            .IsRequired();
            
        modelBuilder.Entity<Checkpoint>()
            .HasOne(ch => ch.Tour)
            .WithMany(t => t.Checkpoints)
            .HasForeignKey(ch => ch.TourId)
            .IsRequired();


        modelBuilder.Entity<TourExecution>()
            .Property(te => te.CheckpointStatuses)
            .HasColumnType("jsonb");
        modelBuilder.Entity<TourExecution>().Property(te => te.CheckpointStatuses).HasColumnType("jsonb");
        modelBuilder.Entity<TourExecution>().Property(te => te.IsComposite).HasDefaultValue(false);
        modelBuilder.Entity<Checkpoint>().Property(sc => sc.Request).HasColumnType("jsonb");
        modelBuilder.Entity<Destination>().Property(sc => sc.Request).HasColumnType("jsonb");

        modelBuilder.Entity<TourExecution>()
            .HasIndex(x => x.TouristId)
            .IsUnique(false);

        modelBuilder.Entity<Tour>()
            .HasMany<TourSaleConnection>()
            .WithOne()
            .HasForeignKey(tsc => tsc.TourId)
            .IsRequired();

        modelBuilder.Entity<Sale>()
            .HasMany<TourSaleConnection>()
            .WithOne()
            .HasForeignKey(tsc => tsc.SaleId)
            .IsRequired();

        modelBuilder.Entity<TourSaleConnection>()
            .HasIndex(tsc => new { tsc.SaleId, tsc.TourId })
            .IsUnique();
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is CompositeTour compositeTour)
            {
                // Handle CompositeTour entity
                foreach (var tour in compositeTour.Tours)
                {
                    // Check if the tour already exists in the database
                    var existingTour = Tours.FirstOrDefault(t => t.Id == tour.Id);

                    if (existingTour != null)
                    {
                        // If the tour exists, attach it to the context
                        Entry(existingTour).State = EntityState.Unchanged;
                    }
                    else
                    {
                        // If the tour doesn't exist, add it to the context
                        Tours.Add(tour);
                    }
                }
            }
        }

        return base.SaveChanges();
    }


}