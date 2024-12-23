using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class HallModelConfig : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.HasKey(k => k.Id);
        
        builder.Property(p => p.Name)
            .IsRequired().HasMaxLength(40);
        
        builder.Property(p => p.Seats).IsRequired();
        builder.Property(p => p.BasePricePerHour).IsRequired();
        
        builder.HasMany(m => m.BookedHalls)
            .WithOne(w => w.Hall)
            .HasForeignKey(k => k.HallId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.AvailableHallServices)
            .WithOne(w => w.Hall)
            .HasForeignKey(k => k.HallId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}