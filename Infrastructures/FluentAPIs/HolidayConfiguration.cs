using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holidays>
    {
        public void Configure(EntityTypeBuilder<Holidays> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
