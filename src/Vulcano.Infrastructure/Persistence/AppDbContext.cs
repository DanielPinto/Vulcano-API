using Microsoft.EntityFrameworkCore;
using Vulcano.Domain.Entities;
using Vulcano.Domain.ValueObjects;

namespace Vulcano.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Equipment> Equipments {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.PurchaseDate).IsRequired();

            // Mapear o ValueObject SerialNumber
            entity.Property(e => e.SerialNumber)
                  .HasConversion(
                      v => v.Value,
                      v => new SerialNumber(v));
        });
    }
}
