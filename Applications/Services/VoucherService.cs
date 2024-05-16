using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.Voucher;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VoucherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreateVoucherAsync(VoucherViewModel voucherViewModel)
        {
            var voucherObj = _mapper.Map<Voucher>(voucherViewModel);
            await _unitOfWork.VoucherRepository.AddAsync(voucherObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<VoucherViewModel>(voucherObj);
                return new Response(HttpStatusCode.OK, "Create success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "create fail");
        }

        public async Task<Response> DeleteVoucherAsync(int id)
        {
            var voucherObj = await _unitOfWork.VoucherRepository.GetByIdAsync(id);
            if (voucherObj is not null)
            {
                _unitOfWork.VoucherRepository.SoftRemove(voucherObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete fail");
        }

        public async Task<Response> GetAllVoucherAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.VoucherRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpdateVoucherAsync(int id, VoucherViewModel voucherViewModel)
        {
            var voucherObj = await _unitOfWork.VoucherRepository.GetByIdAsync(id);
            if (voucherObj is not null)
            {
                _mapper.Map(voucherViewModel, voucherObj);
                _unitOfWork.VoucherRepository.Update(voucherObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<VoucherViewModel>(voucherObj);
                    return new Response(HttpStatusCode.OK, "Update success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update fail");
        }
    }
}
