using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Api.Entities;

namespace StopHere.Api.Data.Mappings.IdentityMappings;

public class IdentityUserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("IdentityUser");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.NormalizedEmail)
            .IsUnique();

        builder.Property(p => p.Email)
            .HasMaxLength(180);

        builder.Property(p => p.NormalizedEmail)
            .HasMaxLength(180);

        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(p => p.PasswordHash);

        builder.Property(p => p.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(p => p.AccessFailedCount);

        builder.Property(p => p.LockoutEnabled);

        builder.Property(p => p.LockoutEnd);

        builder.HasMany<IdentityUserClaim<Guid>>()
            .WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasMany<IdentityUserLogin<Guid>>()
            .WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasMany<IdentityUserToken<Guid>>()
            .WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasMany<IdentityUserRole<Guid>>()
            .WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}
