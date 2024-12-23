using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BookedHallServicesModelConfig : IEntityTypeConfiguration<BookedHallServices>
{
    public void Configure(EntityTypeBuilder<BookedHallServices> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.BookedHalls)
            .WithMany(w => w.BookedHallServices)
            .HasForeignKey(f => f.BookedHallsId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasOne(x => x.Service)
            .WithMany(w => w.BookedHallServices)
            .HasForeignKey(f => f.BookedHallsId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}