using Applications.Repositories;
using Domain.Entities;
namespace Infrastructures.Repositories
{
	internal class SalaryCoefficientRepository : GenericRepository<SalaryCoefficient>, ISalaryCoefficientRepository
	{
		public SalaryCoefficientRepository(AppDBContext appDBContext) : base(appDBContext)
		{
		}
	}
}
