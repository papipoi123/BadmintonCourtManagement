namespace Applications.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public DateTime startTime { get; set; }
        public DateTime sendTime { get; set; }
        public int? paymentId { get; set; } = null;
        public int? voucherId { get; set; } = null;
        public int? holidayId { get; set; } = null;
        public decimal totalPrice { get; set; }
        public int userId { get; set; }
    }
}
