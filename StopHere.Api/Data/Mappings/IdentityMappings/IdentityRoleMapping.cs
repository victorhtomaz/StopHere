using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StopHere.Api.Data.Mappings.IdentityMappings;

public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.ToTable("IdentityRole");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.NormalizedName)
            .IsUnique();

        builder.Property(p => p.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(p => p.Name)
            .HasMaxLength(255);

        builder.Property(p => p.NormalizedName)
            .HasMaxLength(255);

        builder.HasMany<IdentityRoleClaim<Guid>>()
            .WithOne()
            .HasForeignKey(x => x.RoleId)
            .IsRequired();
    }
}
