using Applications.Interfaces;
using Applications.ViewModels.UserViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserViewModel> _validator;
        public UserController(IUserService userService, IValidator<CreateUserViewModel> validator)
        {
            _userService = userService;
            _validator = validator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _userService.Login(loginRequest);
            switch (result.Status)
            {
                case "OK":
                    return Ok(result);
                case "BadRequest":
                    return BadRequest(result);
                default: return NotFound();        
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel createUserViewModel)
        {
            var check = _validator.Validate(createUserViewModel);
            if (check.IsValid)
            {
                var result = await _userService.AddUser(createUserViewModel);
                switch (result.Status)
                {
                    case "OK":
                        return Ok(result);
                    case "BadRequest":
                        return BadRequest(result);
                    case "InternalServerError":
                        return Problem(result.Message);
                    default: return NotFound();
                }
            }
            return BadRequest(check.Errors);
        }

        [HttpPost]
        public Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string comfirmNewPassword, int UserId)
        {
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaff(CreateUserViewModel staff)
        {
            var check = _validator.Validate(staff);
            if (check.IsValid)
            {
                var result = await _userService.AddStaff(staff);
                switch (result.Status)
                {
                    case "OK":
                        return Ok(result);
                    case "BadRequest":
                        return BadRequest(result);
                    case "InternalServerError":
                        return Problem(result.Message);
                    default: return NotFound();
                }
            }
            return BadRequest(check.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> FiterStaff()
        {
            var result = await _userService.FilterStaff();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetStaff(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _userService.GetAllStaff(pageIndex, pageSize);
            return Ok(result);
        }
    }
}
