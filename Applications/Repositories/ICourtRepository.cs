using Applications.Commons;
using Applications.ViewModels.Court;
using Domain.Entities;
using Domain.Enums.Status;

namespace Applications.Repositories
{
    public interface ICourtRepository : IGenericRepository<Court>
    {
        Task<Pagination<Court>> Filter(string? code, int? size, decimal? price, AvailableStatus? availableStatus, ReservationStatus? reservationStatus, int pageIndex = 0, int pageSize = 10);
        Task<CourtDetailModel> CourtDetail(int id);
    }
}
