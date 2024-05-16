using Domain.Base;
using Domain.EntitiesRelationship;
using Domain.Enums.Status;

namespace Domain.Entities
{
    public class Court : BaseEntity
    {
        public string CourtCode { get; set; }
        public string? ImageURI { get; set; }
        public string? Description { get; set; }
        public int? TotalPerson { get; set; }
        public decimal Price { get; set; }
        public AvailableStatus AvailableStatus { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public ICollection<ReservationDetail?> ReservationDetails { get; set; }
    }
}
