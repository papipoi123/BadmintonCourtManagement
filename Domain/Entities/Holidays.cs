using Domain.Base;

namespace Domain.Entities
{
    public class Holidays : BaseEntity
    {
        public string holidayName { get; set; }
        public DateTime holidayDate { get; set; }
        public double workingCoefficient { get; set; }
        public double bookingCoefficient { get; set; }
        public ICollection<Reservation?> Reservation { get; set; }
        public ICollection<WorkingSlotInAMonth?> WorkingSlotInAMonth { get; set; }
    }
}
