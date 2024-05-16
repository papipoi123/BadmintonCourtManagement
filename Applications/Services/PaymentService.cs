using Applications.Interfaces;
using Applications.ViewModels.Payment;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreatePaymentAsync(PaymentViewModel paymentViewModel)
        {
            var paymentObj = _mapper.Map<Payment>(paymentViewModel);
            await _unitOfWork.PaymentRepository.AddAsync(paymentObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<PaymentViewModel>(paymentObj);
                return new Response(HttpStatusCode.OK, "Create payment success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "create payment fail");
        }

        public async Task<Response> DeletePaymentAsync(int id)
        {
            var paymentObj = await _unitOfWork.PaymentRepository.GetByIdAsync(id);
            if (paymentObj is not null)
            {
                _unitOfWork.PaymentRepository.SoftRemove(paymentObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete payment success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete payment fail");
        }

        public async Task<Response> GetAllPaymentAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.PaymentRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpdatePaymentAsync(int id, PaymentViewModel paymentViewModel)
        {
            var paymentObj = await _unitOfWork.PaymentRepository.GetByIdAsync(id);
            if (paymentObj is not null)
            {
                _mapper.Map(paymentViewModel, paymentObj);
                _unitOfWork.PaymentRepository.Update(paymentObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<PaymentViewModel>(paymentObj);
                    return new Response(HttpStatusCode.OK, "Update payment success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update payment fail");
        }
    }
}
