using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings;

public class ClientMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Name");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired(true)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.Name)
            .IsRequired(true)
            .HasColumnName("Name")
            .HasColumnType("NVACHAR")
            .HasMaxLength(125);

        builder.OwnsOne(x => x.Phone)
            .Property(p => p.Number)
            .IsRequired(true)
            .HasColumnName("Phone_Number")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.OwnsOne(x => x.Service)
            .Property(p => p.Type)
            .IsRequired(true)
            .HasColumnName("Service_Type")
            .HasColumnType("SMALLINT");

        builder.OwnsOne(x => x.Service)
            .Property(p => p.ExpiryDate)
            .IsRequired(true)
            .HasColumnName("Service_ExpiryDate")
            .HasColumnType("DATETIME2");

        builder.HasOne(x => x.Vehicle)
            .WithOne(x => x.Client)
            .IsRequired(true)
            .HasForeignKey<Vehicle>(v => v.ClientId);

        builder.HasOne(x => x.ParkingPlace)
            .WithOne(x => x.Client)
            .IsRequired(true)
            .HasForeignKey<ParkingPlace>(p => p.ClientId);
    }
}
