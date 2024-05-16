using Applications.Repositories;
using Domain.Entities;
using Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class UserSlotRepository : GenericRepository<UserSlot>, IUserSlotRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserSlotRepository(AppDBContext appDBContext) : base(appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task CreateUserSlot(UserSlot userSlot)
        {
                userSlot.CreationDate = DateTime.UtcNow;
                await _dbSet.AddAsync(userSlot);
        }

        public async Task<List<UserSlot>> GetAbsentByUserId(int userId)
        {
            return await _appDBContext.UserSlot.Where(x => x.AttendanceStatus == Domain.Enum.AttendenceEnum.AttendenceStatus.Absent && x.userId == userId)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetAbsentBySlotId(int slotId)
        {

            return await _appDBContext.UserSlot.Where(x => x.AttendanceStatus == Domain.Enum.AttendenceEnum.AttendenceStatus.Absent && x.workingSlotInAMonthId == slotId && x.WorkingSlotInAMonth.startTime <= DateTime.UtcNow)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetPresentBySlotId(int slotId)
        {
            return await _appDBContext.UserSlot.Where(x => x.AttendanceStatus == Domain.Enum.AttendenceEnum.AttendenceStatus.Present && x.workingSlotInAMonthId == slotId)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetAllowAbsentByUserId(int userId)
        {
            return await _appDBContext.UserSlot.Where(x => x.AttendanceStatus == Domain.Enum.AttendenceEnum.AttendenceStatus.AllowAbsent && x.userId == userId)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetAllUserSlotByUserId(int userId)
        {
            return await _appDBContext.UserSlot.Where(x => x.userId == userId)
                                               .Include(x => x.Users)
                                               .Include(x => x.WorkingSlotInAMonth)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetPresentByUserId(int userId)
        {
            return await _appDBContext.UserSlot.Where(x => x.AttendanceStatus == Domain.Enum.AttendenceEnum.AttendenceStatus.Present && x.userId == userId)
                                               .ToListAsync();
        }

        public async Task<UserSlot> GetUserSlot(int userId, int workingSlotId)
        {
            return await _appDBContext.UserSlot.FirstOrDefaultAsync(x => x.userId == userId && x.workingSlotInAMonthId == workingSlotId);
        }

        public async Task<List<UserSlot>> GetUserSlotByEmail(string email)
        {
            return await _appDBContext.UserSlot.Where(x => x.Users.email.Contains(email))
                                               .Include(x => x.Users)
                                               .Include(x => x.WorkingSlotInAMonth)
                                               .ToListAsync();
        }

        public async Task<UserSlot> GetUserSlotByUserId(int userId)
        {
            return await _appDBContext.UserSlot.FirstOrDefaultAsync(x => x.userId == userId);
        }
        public async Task<List<UserSlot>> GetUserSlotBySlotId(int slotId)
        {
            return await _appDBContext.UserSlot.Where(x => x.workingSlotInAMonthId == slotId)
                                               .Include(x => x.Users)
                                               .Include(x => x.WorkingSlotInAMonth)
                                               .ToListAsync();
        }

        public async Task<List<UserSlot>> GetUserSlotByUserIdAndWorkingSlotId(int userId, int workingSlotId)
        {
            return await _appDBContext.UserSlot.Where(x => x.userId == userId && x.workingSlotInAMonthId == workingSlotId)
                                               .Include(x => x.Users)
                                               .Include(x => x.WorkingSlotInAMonth)
                                               .ToListAsync();
        }
    }
}
