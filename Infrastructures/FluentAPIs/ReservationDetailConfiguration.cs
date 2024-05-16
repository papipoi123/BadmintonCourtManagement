using Domain.Entities;
using Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ReservationDetailConfiguration : IEntityTypeConfiguration<ReservationDetail>
    {
        public void Configure(EntityTypeBuilder<ReservationDetail> builder)
        {
            builder.HasKey(x => new { x.ReservationId, x.CourtId });
            builder.Ignore(i => i.Id);

            builder.Ignore(i => i.Id);

            builder.HasOne<Reservation>(r => r.Reservation)
                .WithMany(rd => rd.ReservationDetails)
                .HasForeignKey(fk => fk.ReservationId);

            builder.HasOne<Court>(c => c.Court)
                .WithMany(rd => rd.ReservationDetails)
                .HasForeignKey(fk => fk.CourtId);
        }
    }
}
