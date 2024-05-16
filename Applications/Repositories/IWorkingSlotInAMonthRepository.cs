using Applications.ViewModels.Response;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface IWorkingSlotInAMonthRepository : IGenericRepository<WorkingSlotInAMonth>
    {
        Task<List<WorkingSlotInAMonth>> Filter(DateTime start, DateTime end);
        Task AddListWorkingSlotInAMonthAsync(DateTime startDate, DateTime enddate);
    }
}
