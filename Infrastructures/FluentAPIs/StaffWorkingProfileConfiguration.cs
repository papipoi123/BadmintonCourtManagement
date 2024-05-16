using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class StaffWorkingProfileConfiguration : IEntityTypeConfiguration<StaffWorkingProfile>
    {
        public void Configure(EntityTypeBuilder<StaffWorkingProfile> builder)
        {
            builder.HasOne(x => x.Users)
                   .WithMany(x => x.StaffWorkingProfiles)
                   .HasForeignKey(x => x.userId);
        }
    }
}
