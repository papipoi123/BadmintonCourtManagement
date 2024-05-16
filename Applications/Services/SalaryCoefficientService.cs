using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.SalaryCoefficientViewModels;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System.Net;
using Applications.ViewModels.HolidayViewModels;

namespace Applications.Services
{
    public class SalaryCoefficientService : ISalaryCoefficientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalaryCoefficientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> AddSalaryCoefficientAsync(SalaryCoefficientViewModel salaryCoefficientViewModel)
        {
            var SalaryCoefficientObj = _mapper.Map<SalaryCoefficient>(salaryCoefficientViewModel);
            await _unitOfWork.SalaryCoefficientRepository.AddAsync(SalaryCoefficientObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<SalaryCoefficientViewModel>(SalaryCoefficientObj);
                return new Response(HttpStatusCode.OK, "Create SalaryCoefficient Success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "Create SalaryCoefficient Fail");
        }

        public async Task<Response> GetAllSalaryCoefficientAsync(int pageNumber = 0, int pageSize = 10)
        {
            var SalaryCoefficientObj = await _unitOfWork.SalaryCoefficientRepository.ToPagination(pageNumber, pageSize);
            var result = _mapper.Map<Pagination<SalaryCoefficientViewModel>>(SalaryCoefficientObj);
            if (SalaryCoefficientObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "Not Found");
            }
            else
            {
                return new Response(HttpStatusCode.OK, "Load All SalaryCoefficient Success", result);
            }

        }

        public async Task<Response> RemoveSalaryCoefficientAsync(int id)
        {
            var SalaryCoefficientObj = await _unitOfWork.SalaryCoefficientRepository.GetByIdAsync(id);
            if (SalaryCoefficientObj is not null)
            {
                _unitOfWork.SalaryCoefficientRepository.SoftRemove(SalaryCoefficientObj);
                _unitOfWork.SaveChangeAsync();
                return new Response(HttpStatusCode.OK, "Delete SalaryCoefficient Success");
            }
            else
            {
                return new Response(HttpStatusCode.NoContent, "Delete SalaryCoefficient Fail");
            }
        }

        public async Task<Response> UpdateSalaryCoefficientAsync(int id, SalaryCoefficientViewModel salaryCoefficientViewModel)
        {
            var SalaryCoefficientObj = await _unitOfWork.SalaryCoefficientRepository.GetByIdAsync(id);
            if (SalaryCoefficientObj is not null)
            {
                _mapper.Map(salaryCoefficientViewModel, SalaryCoefficientObj);
                _unitOfWork.SalaryCoefficientRepository.Update(SalaryCoefficientObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<SalaryCoefficientViewModel>(SalaryCoefficientObj);
                    return new Response(HttpStatusCode.OK, "Update SalaryCoefficient Success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update SalaryCoefficient Fail");
        }

    }
}

