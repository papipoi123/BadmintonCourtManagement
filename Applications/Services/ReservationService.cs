using Applications.Interfaces;
using Applications.ViewModels.Reservation;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreatePaymentAsync(ReservationViewModel reservationViewModel)
        {
            var reservationObj = _mapper.Map<Reservation>(reservationViewModel);
            await _unitOfWork.ReservationRepository.AddAsync(reservationObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<ReservationViewModel>(reservationObj);
                return new Response(HttpStatusCode.OK, "Create success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "create fail");
        }

        public async Task<Response> DeletePaymentAsync(int id)
        {
            var reservationObj = await _unitOfWork.ReservationRepository.GetByIdAsync(id);
            if (reservationObj is not null)
            {
                _unitOfWork.ReservationRepository.SoftRemove(reservationObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete fail");
        }

        public async Task<Response> GetAllPaymentAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.ReservationRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpdatePaymentAsync(int id, ReservationViewModel reservationViewModel)
        {
            var reservationObj = await _unitOfWork.ReservationRepository.GetByIdAsync(id);
            if (reservationObj is not null)
            {
                _mapper.Map(reservationViewModel, reservationObj);
                _unitOfWork.ReservationRepository.Update(reservationObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<ReservationViewModel>(reservationObj);
                    return new Response(HttpStatusCode.OK, "Update success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update fail");
        }
    }
}
