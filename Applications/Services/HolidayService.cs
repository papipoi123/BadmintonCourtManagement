using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System.Drawing.Printing;
using System.Net;

namespace Applications.Services
{
	public class HolidayService : IHolidayService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public HolidayService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Response> AddHolidayAsync(HolidayViewModel createHolidayViewModel)
		{
			var holidayObj = _mapper.Map<Holidays>(createHolidayViewModel);
			await _unitOfWork.HolidayRepository.AddAsync(holidayObj);
			var isSuccess = await _unitOfWork.SaveChangeAsync();
			if (isSuccess > 0)
			{
				var mapper = _mapper.Map<HolidayViewModel>(holidayObj);
				return new Response(HttpStatusCode.OK, "Create Holiday Success", mapper);
			}
			return new Response(HttpStatusCode.BadRequest, "Create Holiday Fail");
		}

		public async Task<Response> GetAllHolidayAsync(int pageNumber = 0, int pageSize = 10)
		{
			var holidayObj = await _unitOfWork.HolidayRepository.ToPagination(pageNumber, pageSize);
			var result = _mapper.Map<Pagination<HolidayViewModel>>(holidayObj);
			if (holidayObj.Items.Count() < 1)
			{
				return new Response(HttpStatusCode.NoContent, "Not Found");
			}
			else
			{
				return new Response(HttpStatusCode.OK, "Load All Holiday Success", result);
			}

		}

        public async Task<Response> GetHoliddateByDateAsync(DateTime date)
        {
            var holidayObj = await _unitOfWork.HolidayRepository.GetHolidayByDate(date);
			return new Response(HttpStatusCode.OK, "Success", holidayObj);
        }

        public async Task<Response> RemoveHolidayAsync(int id)
		{
			var holidayObj = await _unitOfWork.HolidayRepository.GetByIdAsync(id);
			if (holidayObj is not null)
			{
				_unitOfWork.HolidayRepository.SoftRemove(holidayObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					return new Response(HttpStatusCode.OK, "Delete Holiday Success");
				}
			}
			return new Response(HttpStatusCode.NoContent, "Delete Holiday Fail");

		}

		public async Task<Response> UpdateHolidayAsync(int id, HolidayViewModel updateHolidayViewModel)
		{
			var holidayObj = await _unitOfWork.HolidayRepository.GetByIdAsync(id);
			if (holidayObj is not null)
			{
				_mapper.Map(updateHolidayViewModel, holidayObj);
				_unitOfWork.HolidayRepository.Update(holidayObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					var mapper = _mapper.Map<HolidayViewModel>(holidayObj);
					return new Response(HttpStatusCode.OK, "Update Holiday Success", mapper);

				}
			}
			return new Response(HttpStatusCode.BadRequest, "Update Holiday Fail");
		}

	}
}
