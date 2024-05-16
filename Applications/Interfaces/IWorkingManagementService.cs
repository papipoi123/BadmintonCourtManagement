using Applications.ViewModels.Response;
using Applications.ViewModels.WorkingManagement;

namespace Applications.Interfaces
{
    public interface IWorkingManagementService
    {
        Task<Response> CreateWorkingManagementAsync(WorkingManagementViewModel workingManagementViewModel);
        Task<Response> DeleteWorkingManagementAsync(int id);
        Task<Response> UpdateWorkingManagementAsync(int id, WorkingManagementViewModel workingManagementViewModel);
        Task<Response> GetAllWorkingManagementAsync(int pageNumber = 0, int pageSize = 10);
    }
}
