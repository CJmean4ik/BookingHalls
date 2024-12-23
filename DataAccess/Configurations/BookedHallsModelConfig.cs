using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BookedHallModelConfig : IEntityTypeConfiguration<BookedHall>
{
    public void Configure(EntityTypeBuilder<BookedHall> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(k => k.DateStart).IsRequired();
        builder.Property(k => k.TimeStart).IsRequired();
        builder.Property(k => k.TimeEnd).IsRequired();
        builder.Property(k => k.Price);
        builder.Property(k => k.Duration);
        builder.Property(k => k.BookingStatus).IsRequired();

        builder.HasOne(o => o.Hall)
            .WithMany(w => w.BookedHalls)
            .HasForeignKey(f => f.HallId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(o => o.Booker)
            .WithMany(w => w.BookedHalls)
            .HasForeignKey(f => f.BookerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(o => o.BookedHallServices)
            .WithOne(w => w.BookedHalls)
            .HasForeignKey(f => f.BookedHallsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}