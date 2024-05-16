using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.Court;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Enums.Status;
using System.Net;

namespace Applications.Services
{
    public class CourtService : ICourtService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourtService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreateCourt(CourtModel model)
        {
            var obj = _mapper.Map<Court>(model);
            await _unitOfWork.CourtRepository.AddAsync(obj);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
            {
                return new Response(HttpStatusCode.OK, "Add Suceess", model);
            }
            return new Response(HttpStatusCode.InternalServerError, "Add False", model);
        }

        public async Task<Response> DeleteCourt(int courtId)
        {
            var obj = await _unitOfWork.CourtRepository.GetByIdAsync(courtId);
            if (obj is not null)
            {
                _unitOfWork.CourtRepository.SoftRemove(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete Suceess");
                }
            }
            return new Response(HttpStatusCode.InternalServerError, "Delete False");
        }

        public async Task<Response> Filter(string? code, int? size, decimal? price, AvailableStatus? availableStatus, ReservationStatus? reservationStatus, int pageIndex = 0, int pageSize = 10)
        {
            var result = _mapper.Map<Pagination<CourtModel>>(await _unitOfWork.CourtRepository.Filter(code, size, price, availableStatus, reservationStatus, pageIndex, pageSize));
            return new Response(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Response> GetAllCourt(int pageIndex, int pageSize)
        {
            var result = _mapper.Map<Pagination<CourtModel>>(await _unitOfWork.CourtRepository.ToPagination(pageIndex, pageSize));
            return new Response(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Response> GetCourtById(int courtId)
        {
            var result = _mapper.Map<CourtModel>(await _unitOfWork.CourtRepository.GetByIdAsync(courtId));
            return new Response(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Response> GetCourtDetailById(int id)
        {
            var result = await _unitOfWork.CourtRepository.CourtDetail(id);
            return new Response(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Response> UpdateCourt(int courtId, CourtModel model)
        {
            var obj = await _unitOfWork.CourtRepository.GetByIdAsync(courtId);
            if (obj is not null)
            {
                (AvailableStatus availableStatus, ReservationStatus reservationStatus) = UpdateStatus(model.AvailableStatus, model.ReservationStatus);
                obj.CourtCode = model.CourtCode;
                obj.ImageURI = model.ImageURI;
                obj.Description = model.Description;
                obj.TotalPerson = model.TotalPerson;
                obj.Price = model.Price;
                obj.AvailableStatus = availableStatus;
                obj.ReservationStatus = reservationStatus;

                _unitOfWork.CourtRepository.Update(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Response(HttpStatusCode.OK, "Update Suceess", model);
                }
            }
            return new Response(HttpStatusCode.InternalServerError, "Update False");

        }
        private (AvailableStatus availableStatus, ReservationStatus reservationStatus) UpdateStatus(string availablestatus, string reservationstatus)
        {
            AvailableStatus availableStatus = AvailableStatus.Available;
            ReservationStatus reservationStatus = ReservationStatus.Unknown;
            if (availablestatus == "Available")
            {
                availableStatus = (int)AvailableStatus.Available;
            }
            else if (reservationstatus == "Unknown")
            {
                reservationStatus = (int)ReservationStatus.Unknown;
            }
            return (availableStatus, reservationStatus);
        }
    }
}
