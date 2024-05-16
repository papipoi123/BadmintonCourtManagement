using Domain.Base;
using Domain.EntitiesRelationship;
using Domain.Enums.Status;

namespace Domain.Entities
{
    public class WorkingSlotInAMonth : BaseEntity
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int slotHour { get; set; }
        public double? slotSalary { get; set; }
        public WorkingStatus workingStatus { get; set; }
        public WorkingManagement? WorkingManagement { get; set; }
        public int ?workingManagementId { get; set; }
        public SalaryCoefficient? SalaryCoefficient { get; set; }
        public int ?salaryCoefficientId { get; set; }
        public double? salaryCoefficientBase { get; set; }
        public double? basicSalaryBase { get; set; }
        public Holidays? Holiday { get; set; }
        public int ?holidayId { get; set; }
        public ICollection<UserSlot?> UserSlot { get; set; }
    }
}
