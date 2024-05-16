using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.AbsentRequestViewModels;
using Applications.ViewModels.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Services
{
    public class AbsentRequestService : IAbsentRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AbsentRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> AddAbsentRequestAsync(AbsentRequestViewModel AbsentRequestViewModel)
        {
            var AbsentRequestObj = _mapper.Map<AbsentRequest>(AbsentRequestViewModel);
            await _unitOfWork.AbsentRequestRepository.AddAsync(AbsentRequestObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<AbsentRequestViewModel>(AbsentRequestObj);
                return new Response(HttpStatusCode.OK, "Create AbsentRequest Success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "Create AbsentRequest Fail");
        }

        public async Task<Response> GetAllAbsentRequestAsync(int pageNumber = 0, int pageSize = 10)
        {
            var AbsentRequestObj = await _unitOfWork.AbsentRequestRepository.ToPagination(pageNumber, pageSize);
            var result = _mapper.Map<Pagination<AbsentRequestViewModel>>(AbsentRequestObj);
            if (AbsentRequestObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "Not Found");
            }
            else
            {
                return new Response(HttpStatusCode.OK, "Load All AbsentRequest Success", result);
            }

        }

        public async Task<Response> RemoveAbsentRequestAsync(int id)
        {
            var AbsentRequestObj = await _unitOfWork.AbsentRequestRepository.GetByIdAsync(id);
            if (AbsentRequestObj is not null)
            {
                _unitOfWork.AbsentRequestRepository.SoftRemove(AbsentRequestObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete AbsentRequest Success");
                }
            }
            return new Response(HttpStatusCode.NoContent, "Delete AbsentRequest Fail");
        }

        public async Task<Response> UpdateAbsentRequestAsync(int id, AbsentRequestViewModel AbsentRequestViewModel)
        {
            var AbsentRequestObj = await _unitOfWork.AbsentRequestRepository.GetByIdAsync(id);
            if (AbsentRequestObj is not null)
            {
                _mapper.Map(AbsentRequestViewModel, AbsentRequestObj);
                _unitOfWork.AbsentRequestRepository.Update(AbsentRequestObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<AbsentRequestViewModel>(AbsentRequestObj);
                    return new Response(HttpStatusCode.OK, "Update AbsentRequest Success", mapper);
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update AbsentRequest Fail");
        }
    }
}