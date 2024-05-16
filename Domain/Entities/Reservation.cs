using Domain.Base;
using Domain.EntitiesRelationship;

namespace Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime startTime { get; set; }
        public DateTime sendTime { get; set; }
        public int? paymentId { get; set; }
        public int? voucherId { get; set; }
        public int? holidayId { get; set; }
        public decimal totalPrice { get; set; }
        public int userId { get; set; }
        public Payment? Payment { get; set; }
        public Voucher? Voucher { get; set; }
        public User Users { get; set; }
        public Holidays? Holiday { get; set; }
        public ICollection<ReservationDetail?>? ReservationDetails { get; set; }
    }
}
