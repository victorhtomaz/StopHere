using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StopHere.Api.Data.Mappings.IdentityMappings;

public class IdentityUserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable("IdentityUserLogin");

        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey});

        builder.Property(p => p.LoginProvider)
            .HasMaxLength(128);

        builder.Property(p => p.ProviderKey)
            .HasMaxLength(128);

        builder.Property(p => p.ProviderDisplayName)
            .HasMaxLength(255);
    }
}
