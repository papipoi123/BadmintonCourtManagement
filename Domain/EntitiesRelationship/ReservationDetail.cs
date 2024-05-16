using Domain.Base;
using Domain.Entities;

namespace Domain.EntitiesRelationship
{
    public class ReservationDetail : BaseEntity
    {
        public int CourtId { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public Court Court { get; set; }
        public decimal Price { get; set; }
    }
}
