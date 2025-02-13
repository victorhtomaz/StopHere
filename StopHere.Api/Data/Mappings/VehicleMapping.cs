using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired(true)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(p => p.Color)
                .IsRequired(true)
                .HasColumnName("Color")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(p => p.Model)
                .IsRequired(true)
                .HasColumnName("Model")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.OwnsOne(x => x.LicensePlate)
                .Property(p => p.Value)
                .HasColumnName("LicensePlate_Value")
                .HasColumnType("VARCHAR")
                .HasMaxLength(7);

            builder.OwnsOne(x => x.LicensePlate)
                .HasIndex(p => p.Value)
                .IsUnique();

            builder.HasMany(x => x.EntryExitRecords)
                .WithOne(x => x.Vehicle)
                .IsRequired(true);

            builder.HasOne(x => x.Client)
                .WithOne(x => x.Vehicle)
                .IsRequired(false)
                .HasForeignKey<Vehicle>(v => v.ClientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.ClientId)
                .IsRequired(false)
                .HasColumnName("ClientId")
                .HasColumnType("uniqueidentifier");
        }
    }
}
