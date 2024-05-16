using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
