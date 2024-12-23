using DataAccess.Configurations;
using Domain.Aggregates;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccess.Contexts;

public class BookingHallsContext : DbContext
{
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Booker> Bookers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<BookedHall> BookedHalls { get; set; }
    public DbSet<BookedHallServices> BookedHallServices { get; set; }
    public DbSet<AvailableHallServices> AvailableHallServices { get; set; }

    public BookingHallsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Log.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HallModelConfig());
        modelBuilder.ApplyConfiguration(new BookerModelConfig());
        modelBuilder.ApplyConfiguration(new ServiceModelConfig());
        modelBuilder.ApplyConfiguration(new BookedHallModelConfig());
        modelBuilder.ApplyConfiguration(new BookedHallServicesModelConfig());
        modelBuilder.ApplyConfiguration(new AvailableHallServicesModelConfig());
    }
}