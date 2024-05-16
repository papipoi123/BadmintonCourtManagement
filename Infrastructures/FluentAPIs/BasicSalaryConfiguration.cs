using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class BasicSalaryConfiguration : IEntityTypeConfiguration<BasicSalary>
    {
        public void Configure(EntityTypeBuilder<BasicSalary> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
