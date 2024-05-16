using Applications.ViewModels.Response;
using Applications.ViewModels.UserSlotViewModels;
using Domain.Enum.AttendenceEnum;
using Domain.Enums.Status;

namespace Applications.Interfaces
{
    public interface IUserSlotService
    {
        Task<Response> CreateUserSlotAsync(int userId, int workingSlotId);
        Task<Response> DeleteUserSlotAsync(int userId);
        Task<Response> GetAllUserSlotAsync(int pageNumber = 0, int pageSize = 10);
        Task<Response> GetUserSlotByUserIdAndWorkingSlotId(int userId, int workingSlotId);
        Task<Response> GetUserSlotByUserId(int userId);
        Task<Response> GetAllUserSlotByUserId(int userId);
        Task<Response> GetUserSlotByEmail(string email);
        Task<Response> UpdateAttendanceStatusAsync(int userId, int workingSlotId, AttendenceStatus attendanceStatus);
        Task<Response> CheckAttendanceStatusAsync(int userId, int workingSlotId);
        Task<Response> GetAbsentCountAsync(int userId);
        Task<Response> GetPresentCountAsync(int userId);
        Task<Response> GetAllowAbsentCountAsync(int userId);
    }
}
