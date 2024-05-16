namespace Applications.ViewModels.Court
{
    public class CourtDetailModel
    {
        public string CourtCode { get; set; }
        public string? ImageURI { get; set; }
        public string? Description { get; set; }
        public int? TotalPerson { get; set; }
        public decimal Price { get; set; }
        public string AvailableStatus { get; set; }
        public string ReservationStatus { get; set; }
        public List<Reservation>? Reservations { get; set;}
    }
    public class Reservation
    {
        public DateTime startTime { get; set; }
        public DateTime sendTime { get; set; }
        public decimal totalPrice { get; set; }
        public string paymentType { get; set; }
        public string user { get; set; }
        public string voucherName { get; set; }
        public double discountPercent { get; set; }
    }
}
