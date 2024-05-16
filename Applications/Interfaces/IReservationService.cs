using Applications.ViewModels.Reservation;
using Applications.ViewModels.Response;

namespace Applications.Interfaces
{
    public interface IReservationService
    {
        Task<Response> CreatePaymentAsync(ReservationViewModel reservationViewModel);
        Task<Response> DeletePaymentAsync(int id);
        Task<Response> UpdatePaymentAsync(int id, ReservationViewModel reservationViewModel);
        Task<Response> GetAllPaymentAsync(int pageNumber = 0, int pageSize = 10);
    }
}
