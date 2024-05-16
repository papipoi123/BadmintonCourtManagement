using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class WorkingManagementRepository : GenericRepository<WorkingManagement>, IWorkingManagementRepository
    {
        public WorkingManagementRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
