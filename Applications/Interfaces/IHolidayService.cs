using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;

namespace Applications.Interfaces
{
	public interface IHolidayService
	{
		Task<Response> AddHolidayAsync(HolidayViewModel createHolidayViewModel);
		Task<Response> RemoveHolidayAsync(int id);
		Task<Response> GetAllHolidayAsync(int pageNumber = 0, int pageSize = 10);
		Task<Response> UpdateHolidayAsync(int id, HolidayViewModel updateHolidayViewModel);
		Task<Response> GetHoliddateByDateAsync(DateTime date);
	}
}
