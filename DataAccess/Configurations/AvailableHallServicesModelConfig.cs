using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class AvailableHallServicesModelConfig : IEntityTypeConfiguration<AvailableHallServices>
{
    public void Configure(EntityTypeBuilder<AvailableHallServices> builder)
    {
        builder.HasKey(k => k.Id);
        
        builder.HasOne(x => x.Hall)
            .WithMany(w => w.AvailableHallServices)
            .HasForeignKey(f => f.HallId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasOne(x => x.Service)
            .WithMany(w => w.AvailableHallServices)
            .HasForeignKey(f => f.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}