using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings;

public class EntryExitRecordMapping : IEntityTypeConfiguration<EntryExitRecord>
{
    public void Configure(EntityTypeBuilder<EntryExitRecord> builder)
    {
        builder.ToTable("EntryExitRecord");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired(true)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.EntryDate)
            .IsRequired(true)
            .HasColumnName("EntryDate")
            .HasColumnType("DATETIME2");

        builder.Property(p => p.ExitDate)
            .IsRequired(false)
            .HasColumnName("ExitDate")
            .HasColumnType("DATETIME2");

        builder.Property(p => p.Duration)
            .IsRequired(false)
            .HasColumnName("Duration")
            .HasColumnType("TIME");

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.EntryExitRecords)
            .IsRequired(true)
            .HasForeignKey(e => e.LicensePlateValue)
            .HasPrincipalKey(e => e.LicensePlate.Value);

        builder.Property(x => x.VehicleId)
            .IsRequired(true)
            .HasColumnName("VehicleId")
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.LicensePlateValue)
            .IsRequired(true)
            .HasColumnName("LicensePlateValue")
            .HasColumnType("VARCHAR")
            .HasMaxLength(7);

        builder.HasOne(x => x.ParkingPlace)
            .WithMany()
            .IsRequired(true)
            .HasForeignKey(e => e.ParkingPlaceId);

        builder.Property(x => x.ParkingPlaceId)
            .IsRequired(true)
            .HasColumnName("ParkingPlaceId")
            .HasColumnType("uniqueidentifier");
    }
}
