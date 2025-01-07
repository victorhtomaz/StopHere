using Microsoft.EntityFrameworkCore;
using StopHere.Core.Entities;
using System.Reflection;

namespace StopHere.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<EntryExitRecord> EntryExitRecords { get; set; } = null!;
    public DbSet<ParkingPlace> ParkingPlaces { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
