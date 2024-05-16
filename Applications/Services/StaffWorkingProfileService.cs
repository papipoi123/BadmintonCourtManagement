using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.StaffWorkingProfileViewModels;
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
	public class StaffWorkingProfileService : IStaffWorkingProfileService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public StaffWorkingProfileService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Response> AddStaffWorkingProfileAsync(StaffWorkingProfileViewModel staffWorkingProfileViewModel)
		{
			var staffWorkingProfileObj = _mapper.Map<StaffWorkingProfile>(staffWorkingProfileViewModel);
			await _unitOfWork.StaffWorkingProfileRepository.AddAsync(staffWorkingProfileObj);
			var isSuccess = await _unitOfWork.SaveChangeAsync();
			if (isSuccess > 0)
			{
				var mapper = _mapper.Map<StaffWorkingProfileViewModel>(staffWorkingProfileObj);
				return new Response(HttpStatusCode.OK, "Create StaffWorkingProfile Success", mapper);
			}
			return new Response(HttpStatusCode.BadRequest, "Create StaffWorkingProfile Fail");
		}

		public async Task<Response> GetStaffWorkingProfileByUserId(int UserId)
		{
			var checkser = await _unitOfWork.UserRepository.GetByIdAsync(UserId);
			if (checkser == null)
			{
				return new Response(HttpStatusCode.BadRequest, "UserID Not Found,Try Again");
			}
			var checkprofile = await _unitOfWork.StaffWorkingProfileRepository.GetStaffWorkingProfileByUserId(UserId);
			if (checkprofile != null)
			{
                var stfpabs = await _unitOfWork.UserSlotRepository.GetAbsentByUserId(UserId);
                var stfpaprs = await _unitOfWork.UserSlotRepository.GetPresentByUserId(UserId);
                var countAbs = stfpabs.Count();
                var countPrs = stfpaprs.Count();
                double? salary = 0;
                foreach (var item in stfpaprs)
                {
                    var Wks = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(item.workingSlotInAMonthId);
                    salary = salary + Wks.slotSalary;
                }
                checkprofile.totalAbsent = countAbs;
                checkprofile.totalPresent = countPrs;
                checkprofile.totalSalary = double.Parse(salary.ToString());
                _unitOfWork.StaffWorkingProfileRepository.Update(checkprofile);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess <= 0)
                {
                    return new Response(HttpStatusCode.BadRequest, "SomeThing Wrong,Try Again");
                }
                var stfpexcep = await _unitOfWork.StaffWorkingProfileRepository.GetStaffWorkingProfileByUserId(UserId);
				stfpexcep.Users = null;
                return new Response(HttpStatusCode.OK, "Load StaffWorkingProfile Success", stfpexcep);
			}
			else
			{
				var stfpabs = await _unitOfWork.UserSlotRepository.GetAbsentByUserId(UserId);
				var stfpaprs = await _unitOfWork.UserSlotRepository.GetPresentByUserId(UserId);
				var countAbs = stfpabs.Count();
				var countPrs = stfpaprs.Count();
				double? salary = 0;
				foreach (var item in stfpaprs)
				{
					var Wks = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(item.workingSlotInAMonthId);
					salary = salary + Wks.slotSalary;
				}
				var stfobj = new StaffWorkingProfile();
				stfobj.totalAbsent = countAbs;
				stfobj.userId = UserId;
				stfobj.totalPresent = countPrs;
				stfobj.retireStatus = Domain.Enums.Status.RetireStatus.OnJob;
				stfobj.Users = null;
				stfobj.totalSalary = double.Parse(salary.ToString());
				await _unitOfWork.StaffWorkingProfileRepository.AddAsync(stfobj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess <= 0)
				{
					return new Response(HttpStatusCode.BadRequest, "SomeThing Wrong,Try Again");
				}
				var stfp = await _unitOfWork.StaffWorkingProfileRepository.GetStaffWorkingProfileByUserId(UserId);
				stfp.Users = null;
                return new Response(HttpStatusCode.OK, "Load StaffWorkingProfile Success", stfp);
			}
		}

        public async Task<Response> RemoveStaffWorkingProfileAsync(int id)
		{
			var staffWorkingProfileObj = await _unitOfWork.StaffWorkingProfileRepository.GetByIdAsync(id);
			if (staffWorkingProfileObj is not null)
			{
				_unitOfWork.StaffWorkingProfileRepository.SoftRemove(staffWorkingProfileObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					return new Response(HttpStatusCode.OK, "Delete StaffWorkingProfile Success");
				}
			}
			return new Response(HttpStatusCode.NoContent, "Delete StaffWorkingProfile Fail");
		}

		public async Task<Response> UpdateStaffWorkingProfileAsync(int id, StaffWorkingProfileViewModel staffWorkingProfileViewModel)
		{
			var staffWorkingProfileObj = await _unitOfWork.StaffWorkingProfileRepository.GetByIdAsync(id);
			if (staffWorkingProfileObj is not null)
			{
				_mapper.Map(staffWorkingProfileViewModel, staffWorkingProfileObj);
				_unitOfWork.StaffWorkingProfileRepository.Update(staffWorkingProfileObj);
				var isSuccess = await _unitOfWork.SaveChangeAsync();
				if (isSuccess > 0)
				{
					var mapper = _mapper.Map<StaffWorkingProfileViewModel>(staffWorkingProfileObj);
					return new Response(HttpStatusCode.OK, "Update StaffWorkingProfile Success", mapper);

				}
			}
			return new Response(HttpStatusCode.BadRequest, "Update StaffWorkingProfile Fail");
		}
	}
}
