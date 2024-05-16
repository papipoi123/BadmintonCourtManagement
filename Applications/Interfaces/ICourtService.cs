using Applications.ViewModels.Court;
using Applications.ViewModels.Response;
using Domain.Enums.Status;

namespace Applications.Interfaces
{
    public interface ICourtService
    {
        Task<Response> CreateCourt(CourtModel model);
        Task<Response> DeleteCourt(int courtId);
        Task<Response> UpdateCourt(int courtId, CourtModel model);
        Task<Response> GetCourtById(int courtId);
        Task<Response> GetAllCourt(int pageIndex = 0, int pageSize = 10);
        Task<Response> Filter(string? code, int? size, decimal? price, AvailableStatus? availableStatus, ReservationStatus? reservationStatus, int pageIndex = 0, int pageSize = 10);
        Task<Response> GetCourtDetailById(int id);
    }
}
