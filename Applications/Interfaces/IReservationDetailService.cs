using Applications.ViewModels.ReservationDetailViewModels;
using Applications.ViewModels.Response;

namespace Applications.Interfaces
{
    public interface IReservationDetailService
    {
        Task<Response> CreateReservationDetailAsync(int courtId, int reservationId);
        Task<Response> DeleteReservationDetailAsync(int reservationId);
        Task<Response> GetAllReservationDetailAsync(int pageNumber = 0, int pageSize = 10);
        Task<Response> UpddateReservationDetailAsync(int courtId, int reservationId, ReservationDetailViewModel reservationDetailViewModel);
    }
}
