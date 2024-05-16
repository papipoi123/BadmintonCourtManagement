using Domain.Base;

namespace Domain.Entities
{
    public class SalaryCoefficient : BaseEntity
    {
        public string coefficientName { get; set; }
        public double coefficientForHour { get; set; }
        public ICollection<WorkingSlotInAMonth?> WorkingSlotInAMonth { get; set; }
    }
}
