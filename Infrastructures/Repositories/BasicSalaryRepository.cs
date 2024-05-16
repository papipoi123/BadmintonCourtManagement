using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
	public class BasicSalaryRepository : GenericRepository<BasicSalary>, IBasicSalaryRepository
	{
		public BasicSalaryRepository(AppDBContext appDBContext) : base(appDBContext)
		{
		}
	}
}