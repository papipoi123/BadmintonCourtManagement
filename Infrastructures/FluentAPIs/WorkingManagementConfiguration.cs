using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class WorkingManagementConfiguration : IEntityTypeConfiguration<WorkingManagement>
    {
        public void Configure(EntityTypeBuilder<WorkingManagement> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
