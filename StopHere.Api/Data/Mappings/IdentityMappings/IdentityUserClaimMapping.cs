using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StopHere.Api.Data.Mappings.IdentityMappings;

public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable("IdentityClaim");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.ClaimType)
            .HasMaxLength(255);

        builder.Property(p => p.ClaimValue)
            .HasMaxLength(255);
    }
}
