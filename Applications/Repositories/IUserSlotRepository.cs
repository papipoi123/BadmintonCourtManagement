using Applications.ViewModels.UserSlotViewModels;
using Domain.EntitiesRelationship;

namespace Applications.Repositories
{
    public interface IUserSlotRepository : IGenericRepository<UserSlot>
    {
        Task<List<UserSlot>> GetUserSlotByUserIdAndWorkingSlotId(int userId, int workingSlotId);
        Task<UserSlot> GetUserSlot(int userId, int workingSlotId);
        Task<UserSlot> GetUserSlotByUserId(int userId);
        Task<List<UserSlot>> GetAllUserSlotByUserId(int userId);
        Task CreateUserSlot(UserSlot userSlot);
        Task<List<UserSlot>> GetUserSlotByEmail(string email);
        Task<List<UserSlot>> GetAbsentByUserId(int userId);
        Task<List<UserSlot>> GetPresentByUserId(int userId);
        Task<List<UserSlot>> GetAllowAbsentByUserId(int userId);
        Task<List<UserSlot>> GetUserSlotBySlotId(int slotId);
        Task<List<UserSlot>> GetPresentBySlotId(int slotId);
        Task<List<UserSlot>> GetAbsentBySlotId(int slotId);
    }
}
