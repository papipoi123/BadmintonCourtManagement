using Applications;
using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.BasicSalaryViewModels;
using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
	public class BasicSalaryService : IBasicSalaryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BasicSalaryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Response> AddBasicSalaryAsync(BasicSalaryViewModel basicSalaryViewModel)
		{
			var BasicSalaryObj = _mapper.Map<BasicSalary>(basicSalaryViewModel);
			await _unitOfWork.BasicSalaryRepository.AddAsync(BasicSalaryObj);
			var isSuccess = await _unitOfWork.SaveChangeAsync();
			if (isSuccess > 0)
			{
				var mapper = _mapper.Map<BasicSalaryViewModel>(BasicSalaryObj);
				return new Response(HttpStatusCode.OK, "Create BasicSalary Success", mapper);
			}
			return new Response(HttpStatusCode.BadRequest, "Create BasicSalary Fail");
		}

		public async Task<Response> GetAllBasicSalaryAsync(int pageNumber = 0, int pageSize = 10)
		{
			var BasicSalaryObj = await _unitOfWork.BasicSalaryRepository.ToPagination(pageNumber, pageSize);
			var result = _mapper.Map<Pagination<BasicSalaryViewModel>>(BasicSalaryObj);
			if (BasicSalaryObj.Items.Count() < 1)
			{
				return new Response(HttpStatusCode.NoContent, "Not Found");
			}
			else
			{
				return new Response(HttpStatusCode.OK, "Load All BasicSalary Success", result);
			}

		}

		public async Task<Response> RemoveBasicSalaryAsync(int id)
		{
			var BasicSalaryObj = await _unitOfWork.BasicSalaryRepository.GetByIdAsync(id);
			if (BasicSalaryObj is not null)
			{
				_unitOfWork.BasicSalaryRepository.SoftRemove(BasicSalaryObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					return new Response(HttpStatusCode.OK, "Delete BasicSalary Success");
				}
			}
			return new Response(HttpStatusCode.NoContent, "Delete BasicSalary Fail");
		}

		public async Task<Response> UpdateBasicSalaryAsync(int id, BasicSalaryViewModel basicSalaryViewModel)
		{
			var BasicSalaryObj = await _unitOfWork.BasicSalaryRepository.GetByIdAsync(id);
			if (BasicSalaryObj is not null)
			{
				_mapper.Map(basicSalaryViewModel, BasicSalaryObj);
				_unitOfWork.BasicSalaryRepository.Update(BasicSalaryObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					var mapper = _mapper.Map<BasicSalaryViewModel>(BasicSalaryObj);
					return new Response(HttpStatusCode.OK, "Update BasicSalary Success", mapper);
				}
			}
			return new Response(HttpStatusCode.BadRequest, "Update BasicSalary Fail");
		}
	}
}