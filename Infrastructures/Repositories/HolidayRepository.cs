using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
	public class HolidayRepository : GenericRepository<Holidays>, IHolidayRepository
	{
        private readonly AppDBContext _appDBContext;

        public HolidayRepository(AppDBContext appDBContext) : base(appDBContext)
		{
            _appDBContext = appDBContext;

        }

        public async Task<Holidays> GetHolidayByDate(DateTime dateTime)
        {
            return await _appDBContext.Holiday.FirstOrDefaultAsync(x => x.holidayDate == dateTime);
        }
    }
}
