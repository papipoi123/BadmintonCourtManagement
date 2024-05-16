using Applications.ViewModels.Response;
using Applications.ViewModels.UserViewModels;

namespace Applications.Interfaces
{
    public interface IUserService
    {
        public Task<Response> Login(LoginRequest loginRequest);
        public Task<Response> AddUser(CreateUserViewModel createUserViewModel);
        Task<Response> AddStaff(CreateUserViewModel createUserViewModel);
        Task<Response> DeleteUser(int id);
        Task<Response> GetAllStaff(int pageIndex = 0, int pageSize = 10);
        Task<Response> FilterStaff();
    }
}
