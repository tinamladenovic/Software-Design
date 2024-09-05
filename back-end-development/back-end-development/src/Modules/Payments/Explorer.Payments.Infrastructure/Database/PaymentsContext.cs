using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing;
using Explorer.Payments.Core.Domain.TourPackages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Explorer.Payments.Infrastructure.Database;

public class PaymentsContext : DbContext
{
    public DbSet<ShoppingCart> ShoppingCart { get; set; }
    public DbSet<Wallet> Wallet { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PaymentRecord> PaymentRecords { get; set; }

    public DbSet<ShoppingSessionEvent> ShoppingSessionEvents { get; set; }

    public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("payments");

        modelBuilder.Entity<ShoppingCart>().Property(sc => sc.Items).HasColumnType("jsonb");
        modelBuilder.Entity<ShoppingCart>().Property(sc => sc.BundleItems).HasColumnType("jsonb");

        modelBuilder.Entity<ShoppingCart>().Property(e => e.Items).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<OrderItem>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}));

        
        modelBuilder.Entity<ShoppingSessionEvent>().Property(sc => sc.Changes).HasColumnType("jsonb");
        modelBuilder.Entity<ShoppingSessionEvent>().Property(e => e.Changes).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}),
            v => JsonConvert.DeserializeObject<List<DomainEvent>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        
        modelBuilder.Entity<ShoppingCart>().Property(e => e.BundleItems).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<BundleItem>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        modelBuilder.Entity<TourBundle>().Property(tb => tb.Tours).HasColumnType("jsonb");
        modelBuilder.Entity<TourBundle>()
            .HasIndex(x => x.AuthorId)
            .IsUnique(false);
    }
}

