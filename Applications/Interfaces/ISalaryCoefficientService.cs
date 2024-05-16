using Applications.ViewModels.SalaryCoefficientViewModels;
using Applications.ViewModels.Response;

namespace Applications.Interfaces
{
	public interface ISalaryCoefficientService
	{
		Task<Response> AddSalaryCoefficientAsync(SalaryCoefficientViewModel createSalaryCoefficientViewModel);
		Task<Response> RemoveSalaryCoefficientAsync(int id);
		Task<Response> GetAllSalaryCoefficientAsync(int pageNumber = 0, int pageSize = 10);
		Task<Response> UpdateSalaryCoefficientAsync(int id, SalaryCoefficientViewModel updateSalaryCoefficientViewModel);
	}
}