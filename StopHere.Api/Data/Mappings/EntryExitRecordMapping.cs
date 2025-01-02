using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StopHere.Core.Entities;

namespace StopHere.Api.Data.Mappings
{
    public class EntryExitRecordMapping : IEntityTypeConfiguration<EntryExitRecord>
    {
        public void Configure(EntityTypeBuilder<EntryExitRecord> builder)
        {
            throw new NotImplementedException();
        }
    }
}
