using Applications.Commons;
using Applications.Repositories;
using Domain.Entities;
using Domain.Enums.Role;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateStaff(User staff)
        {
            staff.CreationDate = DateTime.UtcNow;
            staff.role = Role.Staff;
            await _dbSet.AddAsync(staff);
        }

        public Task<List<User>> FilterStaff()
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<User>> GetAllStaff(int pageIndex = 0, int pageSize = 10)
        {
            var count = await _dbContext.User.Where(x => x.role == Role.Staff).CountAsync();
            var items = await _dbContext.User.Where(x => x.role == Role.Staff).Skip(pageSize * pageIndex).Take(pageSize).AsNoTracking().ToListAsync();
            var result = new Pagination<User>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = count,
                Items = items,
            };
            return result;
        }

        public async Task<User?> GetUserByEmail(string email) => _dbContext.User.FirstOrDefault(u => u.email.Equals(email));
    }
}
