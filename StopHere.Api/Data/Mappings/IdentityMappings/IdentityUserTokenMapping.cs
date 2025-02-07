using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StopHere.Api.Data.Mappings.IdentityMappings
{
    public class IdentityUserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            builder.ToTable("IdentityUserToken");

            builder.HasKey(x => new { x.UserId , x.LoginProvider, x.Name});

            builder.Property(p => p.LoginProvider)
                .HasMaxLength(120);

            builder.Property(p => p.Name)
                .HasMaxLength(180);
        }
    }
}
