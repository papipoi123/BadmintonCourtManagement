using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
