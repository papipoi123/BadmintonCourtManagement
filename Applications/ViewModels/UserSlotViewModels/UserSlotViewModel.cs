using Domain.Enum.AttendenceEnum;
using Domain.Enums.Status;

namespace Applications.ViewModels.UserSlotViewModels
{
    public class UserSlotViewModel
    {
        public int userId { get; set; }
        public int workingSlotInAMonthId { get; set; }
        public AttendenceStatus AttendanceStatus { get; set; }
    }
}
