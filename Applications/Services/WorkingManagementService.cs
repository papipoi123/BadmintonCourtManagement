using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.WorkingManagement;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class WorkingManagementService : IWorkingManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkingManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreateWorkingManagementAsync(WorkingManagementViewModel workingManagementViewModel)
        {
            var workingManagementObj = _mapper.Map<WorkingManagement>(workingManagementViewModel);
            await _unitOfWork.WorkingManagementRepository.AddAsync(workingManagementObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<WorkingManagementViewModel>(workingManagementObj);
                return new Response(HttpStatusCode.OK, "Create success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "create fail");
        }

        public async Task<Response> DeleteWorkingManagementAsync(int id)
        {
            var workingManagementObj = await _unitOfWork.WorkingManagementRepository.GetByIdAsync(id);
            if (workingManagementObj is not null)
            {
                _unitOfWork.WorkingManagementRepository.SoftRemove(workingManagementObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete fail");
        }

        public async Task<Response> GetAllWorkingManagementAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.WorkingManagementRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> UpdateWorkingManagementAsync(int id, WorkingManagementViewModel workingManagementViewModel)
        {
            var workingManagementObj = await _unitOfWork.WorkingManagementRepository.GetByIdAsync(id);
            if (workingManagementObj is not null)
            {
                _mapper.Map(workingManagementViewModel, workingManagementObj);
                _unitOfWork.WorkingManagementRepository.Update(workingManagementObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<WorkingManagementViewModel>(workingManagementObj);
                    return new Response(HttpStatusCode.OK, "Update success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update fail");
        }
    }
}
