using Applications.ViewModels.BasicSalaryViewModels;
using Applications.ViewModels.Response;
namespace Applications.Interfaces
{
	public interface IBasicSalaryService
	{
		Task<Response> AddBasicSalaryAsync(BasicSalaryViewModel basicSalaryViewModel);
		Task<Response> RemoveBasicSalaryAsync(int id);
		Task<Response> GetAllBasicSalaryAsync(int pageNumber = 0, int pageSize = 10);
		Task<Response> UpdateBasicSalaryAsync(int id, BasicSalaryViewModel basicSalaryViewModel);
	}
}
