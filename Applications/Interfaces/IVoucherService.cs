using Applications.ViewModels.Response;
using Applications.ViewModels.Voucher;

namespace Applications.Interfaces
{
    public interface IVoucherService
    {
        Task<Response> CreateVoucherAsync(VoucherViewModel voucherViewModel);
        Task<Response> DeleteVoucherAsync(int id);
        Task<Response> UpdateVoucherAsync(int id, VoucherViewModel voucherViewModel);
        Task<Response> GetAllVoucherAsync(int pageNumber = 0, int pageSize = 10);
    }
}
