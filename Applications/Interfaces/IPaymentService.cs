using Applications.ViewModels.Payment;
using Applications.ViewModels.Response;

namespace Applications.Interfaces
{
    public interface IPaymentService
    {
        Task<Response> CreatePaymentAsync(PaymentViewModel paymentViewModel);
        Task<Response> DeletePaymentAsync(int id);
        Task<Response> UpdatePaymentAsync(int id, PaymentViewModel paymentViewModel);
        Task<Response> GetAllPaymentAsync(int pageNumber = 0, int pageSize = 10);
    }
}
