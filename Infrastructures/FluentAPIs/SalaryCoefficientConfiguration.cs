using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class SalaryCoefficientConfiguration : IEntityTypeConfiguration<SalaryCoefficient>
    {
        public void Configure(EntityTypeBuilder<SalaryCoefficient> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
