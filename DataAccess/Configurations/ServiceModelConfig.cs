using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class ServiceModelConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(x => x.Id); 
        builder.Property(x => x.Name).IsRequired(); 
        builder.Property(x => x.Price).IsRequired(); 
        
        builder.HasMany(x => x.AvailableHallServices)
            .WithOne(w => w.Service)
            .HasForeignKey(f => f.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasMany(x => x.BookedHallServices)
            .WithOne(w => w.Service)
            .HasForeignKey(f => f.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}