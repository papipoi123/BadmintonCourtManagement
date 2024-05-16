using Domain.Base;

namespace Domain.Entities
{
    public class Voucher : BaseEntity
    {
        public string voucherName { get; set; }
        public double discountPercent { get; set; }
        public ICollection<Reservation?> Reservations { get; set; }
    }
}
