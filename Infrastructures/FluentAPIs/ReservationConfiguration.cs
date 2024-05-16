using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.totalPrice).HasColumnType("money");

            builder.HasOne(x => x.Holiday)
                   .WithMany(x => x.Reservation)
                   .HasForeignKey(x => x.holidayId);

            builder.HasOne(x => x.Payment)
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.paymentId);

            builder.HasOne(x => x.Voucher)
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.voucherId);

            builder.HasOne(x => x.Users)
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.userId);
        }
    }
}
