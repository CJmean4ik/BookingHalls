using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BookerModelConfig : IEntityTypeConfiguration<Booker>
{
    public void Configure(EntityTypeBuilder<Booker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Surname);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.HashedPassword).IsRequired();
        builder.Property(x => x.SaltPassword).IsRequired();
        
        builder.HasMany(o => o.BookedHalls)
            .WithOne(w => w.Booker)
            .HasForeignKey(f => f.BookerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}