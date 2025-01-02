using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            throw new NotImplementedException();
        }
    }
}
