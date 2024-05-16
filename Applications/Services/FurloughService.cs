using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.FurloughViewModels;
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
    public class FurloughService : IFurloughService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FurloughService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> AddFurloughAsync(FurloughViewModel createFurloughViewModel)
        {
            var FurloughObj = _mapper.Map<Furlough>(createFurloughViewModel);
            await _unitOfWork.FurloughRepository.AddAsync(FurloughObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                var mapper = _mapper.Map<FurloughViewModel>(FurloughObj);
                return new Response(HttpStatusCode.OK, "Create Furlough Success", mapper);
            }
            return new Response(HttpStatusCode.BadRequest, "Create Furlough Fail");
        }

        public async Task<Response> GetAllFurloughAsync(int pageNumber = 0, int pageSize = 10)
        {
            var FurloughObj = await _unitOfWork.FurloughRepository.ToPagination(pageNumber, pageSize);
            var result = _mapper.Map<Pagination<FurloughViewModel>>(FurloughObj);
            if (FurloughObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "Not Found");
            }
            else
            {
                return new Response(HttpStatusCode.OK, "Load All Furlough Success", result);
            }

        }

        public async Task<Response> RemoveFurloughAsync(int id)
        {
            var FurloughObj = await _unitOfWork.FurloughRepository.GetByIdAsync(id);
            if (FurloughObj is not null)
            {
                _unitOfWork.FurloughRepository.SoftRemove(FurloughObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete Furlough Success");
                }
            }
            return new Response(HttpStatusCode.NoContent, "Delete Furlough Fail");

        }

        public async Task<Response> UpdateFurloughAsync(int id, FurloughViewModel updateFurloughViewModel)
        {
            var FurloughObj = await _unitOfWork.FurloughRepository.GetByIdAsync(id);
            if (FurloughObj is not null)
            {
                _mapper.Map(updateFurloughViewModel, FurloughObj);
                _unitOfWork.FurloughRepository.Update(FurloughObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    var mapper = _mapper.Map<FurloughViewModel>(FurloughObj);
                    return new Response(HttpStatusCode.OK, "Update Furlough Success", mapper);

                }
            }
            return new Response(HttpStatusCode.BadRequest, "Update Furlough Fail");
        }

    }
}
