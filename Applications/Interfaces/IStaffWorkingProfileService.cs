using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;
using Applications.ViewModels.StaffWorkingProfileViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
	public interface IStaffWorkingProfileService
	{
		Task<Response> AddStaffWorkingProfileAsync(StaffWorkingProfileViewModel	staffWorkingProfileViewModel);
		Task<Response> RemoveStaffWorkingProfileAsync(int id);
		Task<Response> UpdateStaffWorkingProfileAsync(int id, StaffWorkingProfileViewModel staffWorkingProfileViewModel);
		Task<Response> GetStaffWorkingProfileByUserId(int UserId);

    }
}
