using Applications.Interfaces;
using Applications.ViewModels.ReservationDetailViewModels;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.EntitiesRelationship;
using System.Net;

namespace Applications.Services
{
    public class ReservationDetailService : IReservationDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreateReservationDetailAsync(int courtId, int reservationId)
        {
            var courtObj = await _unitOfWork.CourtRepository.GetByIdAsync(courtId);

            if (courtObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "Court Not Found");
            }

            var reservationObj = await _unitOfWork.ReservationRepository.GetByIdAsync(reservationId);

            if (reservationObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "Reservation Not Found");
            }

            var reservationDetailObj = new ReservationDetail
            {
                CourtId = courtId,
                ReservationId = reservationId,
                Price = (courtObj.Price * reservationObj.totalPrice)
            };

            await _unitOfWork.ReservationDetailRepository.AddAsync(reservationDetailObj);

            var isSuccess = await _unitOfWork.SaveChangeAsync();

            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Add Success", _mapper.Map<ReservationDetailViewModel>(reservationDetailObj));
            }

            return new Response(HttpStatusCode.BadRequest, "Add Fail");
        }

        public async Task<Response> DeleteReservationDetailAsync(int reservationId)
        {
            var reservationObj = await _unitOfWork.ReservationDetailRepository.GetReservationDetailByReservationId(reservationId);
            if (reservationObj is not null)
            {
                _unitOfWork.ReservationDetailRepository.SoftRemove(reservationObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete Fail");
        }

        public async Task<Response> GetAllReservationDetailAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.ReservationDetailRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpddateReservationDetailAsync(int courtId, int reservationId, ReservationDetailViewModel reservationDetailViewModel)
        {
            var reservationDetailObj = await _unitOfWork.ReservationDetailRepository.GetReservationDetail(courtId, reservationId);
            if (reservationDetailObj is not null)
            {
                _mapper.Map(reservationDetailViewModel, reservationDetailObj);
                _unitOfWork.ReservationDetailRepository.Update(reservationDetailObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Update Success", _mapper.Map<ReservationDetailViewModel>(reservationDetailViewModel));
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update Fail");
        }
    }
}
