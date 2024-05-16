using Applications.ViewModels.FurloughViewModels;
using Applications.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
    public interface IFurloughService
    {
        Task<Response> AddFurloughAsync(FurloughViewModel createFurloughViewModel);
        Task<Response> RemoveFurloughAsync(int id);
        Task<Response> GetAllFurloughAsync(int pageNumber = 0, int pageSize = 10);
        Task<Response> UpdateFurloughAsync(int id, FurloughViewModel updateFurloughViewModel);
    }
}
