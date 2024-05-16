using Domain.EntitiesRelationship;

namespace Applications.Repositories
{
    public interface IReservationDetailRepository : IGenericRepository<ReservationDetail>
    {
        Task<ReservationDetail> GetReservationDetail(int courtId, int reservationId);
        Task<ReservationDetail> GetReservationDetailByReservationId(int reservationId);
    }
}
