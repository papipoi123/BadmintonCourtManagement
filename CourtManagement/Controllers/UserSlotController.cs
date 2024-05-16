using Applications.Interfaces;
using Applications.ViewModels.UserSlotViewModels;
using Domain.Enum.AttendenceEnum;
using Domain.Enums.Status;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSlotController : ControllerBase
    {
        private readonly IUserSlotService _userSlotService;
        private readonly IValidator<UserSlotViewModel> _validator;

        public UserSlotController(IUserSlotService userSlotService, IValidator<UserSlotViewModel> validator)
        {
            _userSlotService = userSlotService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserSlot(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _userSlotService.GetAllUserSlotAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{userId}/{workingSlotId}")]
        public async Task<IActionResult> GetUserSlotByUserIdAndWorkingSlotId(int userId, int workingSlotId)
        {
            var result = await _userSlotService.GetUserSlotByUserIdAndWorkingSlotId(userId, workingSlotId);
            return Ok(result);
        }

        [HttpPost("{userId}/{workingSlotId}")]
        public async Task<IActionResult> AddUserSlot(int userId, int workingSlotId)
        {
            var result = await _userSlotService.CreateUserSlotAsync(userId, workingSlotId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserSlot(int userId)
        {
            var result = await _userSlotService.DeleteUserSlotAsync(userId);
            return Ok(result);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserSlotByUserId(int userId)
        {
            var result = await _userSlotService.GetUserSlotByUserId(userId);
            return Ok(result);
        }

        [HttpGet("GetAllUserSlotByUserId/{userId:int}")]
        public async Task<IActionResult> GetAllUserSlotByUserId(int userId)
        {
            var result = await _userSlotService.GetAllUserSlotByUserId(userId);
            return Ok(result);
        }

        [HttpGet("{email:alpha}")]
        public async Task<IActionResult> GetUserSlotByEmail(string email)
        {
            var result = await _userSlotService.GetUserSlotByEmail(email);
            return Ok(result);
        }

        [HttpPut("{userId}/{workingSlotId}")]
        public async Task<IActionResult> CheckAttendance(int userId, int workingSlotId)
        {
            var result = await _userSlotService.CheckAttendanceStatusAsync(userId, workingSlotId);
            return Ok(result);
        }

        [HttpPut("{userId}/{workingSlotId}/{attendanceStatus}")]
        public async Task<IActionResult> UpdateAttendance(int userId, int workingSlotId, AttendenceStatus attendanceStatus)
        {
            var result = await _userSlotService.UpdateAttendanceStatusAsync(userId, workingSlotId, attendanceStatus);
            return Ok(result);
        }

        [HttpGet("GetAbsentCount/{userId}")]
        public async Task<IActionResult> GetAbsentCount(int userId)
        {
            var result = await _userSlotService.GetAbsentCountAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetAllowAbsentCount/{userId}")]
        public async Task<IActionResult> GetAllowAbsentCount(int userId)
        {
            var result = await _userSlotService.GetAllowAbsentCountAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetPresentAbsentCount/{userId}")]
        public async Task<IActionResult> GetPresentAbsentCount(int userId)
        {
            var result = await _userSlotService.GetPresentCountAsync(userId);
            return Ok(result);
        }
    }
}
