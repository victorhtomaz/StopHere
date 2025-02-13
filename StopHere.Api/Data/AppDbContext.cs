using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StopHere.Api.Entities;
using StopHere.Core.Entities;
using System.Reflection;

namespace StopHere.Api.Data;

public class AppDbContext : 
    IdentityDbContext<User, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>,
            IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
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
