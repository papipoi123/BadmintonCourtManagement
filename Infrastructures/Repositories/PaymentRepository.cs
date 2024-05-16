using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
