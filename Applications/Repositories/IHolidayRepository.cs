using Domain.Entities;

namespace Applications.Repositories
{
	public interface IHolidayRepository : IGenericRepository<Holidays>
	{
		Task<Holidays> GetHolidayByDate(DateTime dateTime);
	}
}
