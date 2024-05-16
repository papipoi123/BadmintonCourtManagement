using Domain.Entities;
using Domain.EntitiesRelationship;
using Domain.Enums.Status;

namespace Applications.ViewModels.WorkingSlotInAMonth
{
    public class WorkingSlotInAMonthViewModel
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int slotHour { get; set; }
        public double slotSalary { get; set; }
        public WorkingStatus workingStatus { get; set; }
        public double? salaryCoefficientBase { get; set; }
        public double? basicSalaryBase { get; set; }
    }
}
