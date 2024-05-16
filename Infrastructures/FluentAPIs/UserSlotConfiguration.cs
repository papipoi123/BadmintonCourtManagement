using Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class UserSlotConfiguration : IEntityTypeConfiguration<UserSlot>
    {
        public void Configure(EntityTypeBuilder<UserSlot> builder)
        {
            builder.HasKey(x => new { x.workingSlotInAMonthId, x.userId });

            builder.Ignore(i => i.Id);

            builder.HasOne(x => x.WorkingSlotInAMonth)
                   .WithMany(x => x.UserSlot)
                   .HasForeignKey(x => x.workingSlotInAMonthId);

            builder.HasOne(x => x.Users)
                   .WithMany(x => x.UserSlots)
                   .HasForeignKey(x => x.userId);
        }
    }
}
