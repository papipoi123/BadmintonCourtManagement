using Applications.ViewModels.AbsentRequestViewModels;
using Applications.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
    public interface IAbsentRequestService
    {
        Task<Response> AddAbsentRequestAsync(AbsentRequestViewModel AbsentRequestViewModel);
        Task<Response> RemoveAbsentRequestAsync(int id);
        Task<Response> GetAllAbsentRequestAsync(int pageNumber = 0, int pageSize = 10);
        Task<Response> UpdateAbsentRequestAsync(int id, AbsentRequestViewModel AbsentRequestViewModel);
    }
}
