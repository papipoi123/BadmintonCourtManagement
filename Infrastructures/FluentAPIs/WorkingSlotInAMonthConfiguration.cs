using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class WorkingSlotInAMonthConfiguration : IEntityTypeConfiguration<WorkingSlotInAMonth>
    {
        public void Configure(EntityTypeBuilder<WorkingSlotInAMonth> builder)
        {
            builder.HasKey(x => x.Id);            
            builder.HasOne(x => x.Holiday)
                   .WithMany(x => x.WorkingSlotInAMonth)
                   .HasForeignKey(x => x.holidayId);

            builder.HasOne(x => x.SalaryCoefficient)
                   .WithMany(x => x.WorkingSlotInAMonth)
                   .HasForeignKey(x => x.salaryCoefficientId);

            builder.HasOne(x => x.WorkingManagement)
                   .WithMany(x => x.WorkingSlotInAMonth)
                   .HasForeignKey(x => x.workingManagementId);
        }
    }
}
