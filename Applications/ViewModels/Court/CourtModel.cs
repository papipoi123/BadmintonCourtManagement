using Domain.Enums.Status;

namespace Applications.ViewModels.Court
{
    public class CourtModel
    {
        public int Id { get; set; }
        public string CourtCode { get; set; }
        public string? ImageURI { get; set; }
        public string? Description { get; set; }
        public int? TotalPerson { get; set; }
        public decimal Price { get; set; }
        public string AvailableStatus { get; set; }
        public string ReservationStatus { get; set; }
    }
}
