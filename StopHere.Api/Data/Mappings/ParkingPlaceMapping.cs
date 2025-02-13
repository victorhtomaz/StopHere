using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings;

public class ParkingPlaceMapping : IEntityTypeConfiguration<ParkingPlace>
{
    public void Configure(EntityTypeBuilder<ParkingPlace> builder)
    {
        builder.ToTable("ParkingPlace");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired(true)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.Number)
            .IsRequired(true)
            .HasColumnName("Number")
            .HasColumnType("INT");

        builder.HasIndex(p => p.Number)
            .IsUnique();

        builder.Property(p => p.IsOccupied)
            .IsRequired(true)
            .HasColumnName("IsOccupied")
            .HasColumnType("BIT");

        builder.HasOne(x => x.Client)
            .WithOne(x => x.ParkingPlace)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.ClientId)
            .IsRequired(false)
            .HasColumnName("ClientId")
            .HasColumnType("uniqueidentifier");
    }
}
