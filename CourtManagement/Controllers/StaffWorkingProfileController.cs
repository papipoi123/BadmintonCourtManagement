using Applications.Interfaces;
using Applications.Services;
using Applications.ViewModels.StaffWorkingProfileViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffWorkingProfileController : ControllerBase
	{
		private readonly IStaffWorkingProfileService _staffWorkingProfileService;
		private readonly IValidator<StaffWorkingProfileViewModel> _validator;

		public StaffWorkingProfileController(IStaffWorkingProfileService StaffWorkingProfileService, IValidator<StaffWorkingProfileViewModel> validator)
		{
			_staffWorkingProfileService = StaffWorkingProfileService;
			_validator = validator;
		}

        [HttpGet("GetStaffWowrkingProfileByUserId/{userId:int}")]
        public async Task<IActionResult> GetAllUserSlotByUserId(int userId)
        {
            var result = await _staffWorkingProfileService.GetStaffWorkingProfileByUserId(userId);
            return Ok(result);
        }

        [HttpPost]
		public async Task<IActionResult> AddStaffWorkingProfileAsync(StaffWorkingProfileViewModel staffWorkingProfileViewModel)
		{
			var validation = _validator.Validate(staffWorkingProfileViewModel);
			if (validation.IsValid)
			{
				var result = await _staffWorkingProfileService.AddStaffWorkingProfileAsync(staffWorkingProfileViewModel);
				if (result is not null)
				{
					return Ok(result);
				}
				else
				{
					return BadRequest("Fail Add StaffWorkingProfile");
				}
			}
			return BadRequest("Invalid Information StaffWorkingProfile");
		}

		[HttpPut("{StaffWorkingProfileId}")]
		public async Task<IActionResult> UpdateStaffWorkingProfileAsync(int StaffWorkingProfileId, StaffWorkingProfileViewModel staffWorkingProfileViewModel)
		{
			var validation = _validator.Validate(staffWorkingProfileViewModel);
			if (validation.IsValid)
			{
				var result = await _staffWorkingProfileService.UpdateStaffWorkingProfileAsync(StaffWorkingProfileId, staffWorkingProfileViewModel);
				return Ok(result);
			}
			return BadRequest("Invalid Information StaffWorkingProfile");

		}

		[HttpDelete("{StaffWorkingProfileId}")]
		public async Task<IActionResult> DeleteStaffWorkingProfileAsync(int StaffWorkingProfileId)
		{
			var result = await _staffWorkingProfileService.RemoveStaffWorkingProfileAsync(StaffWorkingProfileId);
			return Ok(result);
		}
	}
}
