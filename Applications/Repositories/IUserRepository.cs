using Applications.Commons;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface IUserRepository :  IGenericRepository<User>
    {
        public Task<User?> GetUserByEmail(string email);
        public Task CreateStaff(User staff);
        public Task<Pagination<User>> GetAllStaff(int pageIndex = 0, int pageSize = 10);
        public Task<List<User>> FilterStaff();
    }
}
