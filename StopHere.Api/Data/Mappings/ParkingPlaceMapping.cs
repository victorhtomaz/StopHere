using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings
{
    public class ParkingPlaceMapping : IEntityTypeConfiguration<ParkingPlace>
    {
        public void Configure(EntityTypeBuilder<ParkingPlace> builder)
        {
            throw new NotImplementedException();
        }
    }
}
