using Applications.ViewModels.Response;
using Applications.ViewModels.WorkingSlotInAMonth;

namespace Applications.Interfaces
{
    public interface IWorkingSlotInAMonthService
    {
        Task<Response> CreateWorkingSlotInAMonthAsync(WorkingSlotInAMonthViewModel workingSlotInAMonthViewModel);
        Task<Response> DeleteWorkingSlotInAMonthAsync(int id);
        Task<Response> UpdateWorkingSlotInAMonthAsync(int id, WorkingSlotInAMonthViewModel workingSlotInAMonthViewModel);
        Task<Response> GetAllWorkingSlotInAMonthAsync(int pageNumber = 0, int pageSize = 10);
        Task<Response> Filter(DateTime start, DateTime end);
        Task<Response> AddListWorkingSlotInAMonthAsync(DateTime startDate, DateTime enddate);
        Task<Response> GetWorkingSLotInAMonthByID(int WKSId);
    }
}
