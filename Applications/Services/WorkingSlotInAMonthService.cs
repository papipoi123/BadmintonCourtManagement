using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.WorkingManagement;
using Applications.ViewModels.WorkingSlotInAMonth;
using AutoMapper;
using Domain.Entities;
using System.Net;
using System.Security.Cryptography.Xml;

namespace Applications.Services
{
    public class WorkingSlotInAMonthService : IWorkingSlotInAMonthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkingSlotInAMonthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> AddListWorkingSlotInAMonthAsync(DateTime startDate, DateTime enddate)
        {
            if (startDate < enddate)
            {
                await _unitOfWork.WorkingSlotInAMonthRepository.AddListWorkingSlotInAMonthAsync(startDate, enddate);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    return new Response(HttpStatusCode.OK, "Create Attendance Succeed");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Create Attendance failed,check starDate must be smaller than endDate");
        }

        public async Task<Response> CreateWorkingSlotInAMonthAsync(WorkingSlotInAMonthViewModel workingSlotInAMonthViewModel)
        {
            var workingSlotInAMonthObj = _mapper.Map<WorkingSlotInAMonth>(workingSlotInAMonthViewModel);
            await _unitOfWork.WorkingSlotInAMonthRepository.AddAsync(workingSlotInAMonthObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<WorkingSlotInAMonthViewModel>(workingSlotInAMonthObj);
                return new Response(HttpStatusCode.OK, "Create success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "create fail");
        }

        public async Task<Response> DeleteWorkingSlotInAMonthAsync(int id)
        {
            var workingSlotInAMonthObj = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(id);
            if (workingSlotInAMonthObj is not null)
            {
                _unitOfWork.WorkingSlotInAMonthRepository.SoftRemove(workingSlotInAMonthObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete fail");
        }
        public async Task<Response> GetWorkingSLotInAMonthByID(int WKSId)
        {
            var wks = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(WKSId);
            if (wks == null) return new Response(HttpStatusCode.NoContent, "Id not found");
            else return new Response(HttpStatusCode.OK, "Search succeed", wks);
        }
        public async Task<Response> Filter(DateTime start, DateTime end)
        {
            var result = await _unitOfWork.WorkingSlotInAMonthRepository.Filter(start, end);
            return new Response(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Response> GetAllWorkingSlotInAMonthAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.WorkingSlotInAMonthRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpdateWorkingSlotInAMonthAsync(int id, WorkingSlotInAMonthViewModel workingSlotInAMonthViewModel)
        {
            var workingSlotInAMonthObj = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(id);
            if (workingSlotInAMonthObj is not null)
            {
                _mapper.Map(workingSlotInAMonthViewModel, workingSlotInAMonthObj);
                _unitOfWork.WorkingSlotInAMonthRepository.Update(workingSlotInAMonthObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<WorkingSlotInAMonthViewModel>(workingSlotInAMonthObj);
                    return new Response(HttpStatusCode.OK, "Update success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update fail");
        }
    }
}
