using Domain.Base;
using Domain.Entities;
using Domain.Enum.AttendenceEnum;
using Domain.Enums.Status;

namespace Domain.EntitiesRelationship
{
    public class UserSlot : BaseEntity
    {
        public int userId { get; set; }
        public int workingSlotInAMonthId { get; set; }
        public User Users { get; set; }
        public WorkingSlotInAMonth WorkingSlotInAMonth { get; set; }
        public AttendenceStatus AttendanceStatus { get; set; }
    }
}
