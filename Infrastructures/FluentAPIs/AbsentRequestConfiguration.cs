using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class AbsentRequestConfiguration : IEntityTypeConfiguration<AbsentRequest>
    {
        public void Configure(EntityTypeBuilder<AbsentRequest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Users)
                   .WithMany(x => x.AbsentRequests)
                   .HasForeignKey(x => x.userId);
        }
    }
}
