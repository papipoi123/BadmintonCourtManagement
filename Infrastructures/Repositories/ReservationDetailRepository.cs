using Applications.Repositories;
using Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class ReservationDetailRepository : GenericRepository<ReservationDetail>, IReservationDetailRepository
    {
        private readonly AppDBContext _appDBContext;

        public ReservationDetailRepository(AppDBContext appDBContext) : base(appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<ReservationDetail> GetReservationDetail(int courtId, int reservationId)
        {
            return await _appDBContext.ReservationDetail.FirstOrDefaultAsync(x => x.CourtId == courtId && x.ReservationId == reservationId);
        }

        public async Task<ReservationDetail> GetReservationDetailByReservationId(int reservationId)
        {
            return await _appDBContext.ReservationDetail.FirstOrDefaultAsync(x => x.ReservationId == reservationId);
        }
    }
}
