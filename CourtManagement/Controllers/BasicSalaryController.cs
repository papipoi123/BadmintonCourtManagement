using Applications.Interfaces;
using Applications.Services;
using Applications.ViewModels.BasicSalaryViewModels;
using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicSalaryController : ControllerBase
    {
        private readonly IBasicSalaryService _basicSalaryService;
        private readonly IValidator<BasicSalaryViewModel> _validator;

        public BasicSalaryController(IBasicSalaryService basicSalaryService, IValidator<BasicSalaryViewModel> validator)
        {
            _basicSalaryService = basicSalaryService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasicSalaryAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _basicSalaryService.GetAllBasicSalaryAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasicSalaryAsync(BasicSalaryViewModel basicSalaryViewModel)
        {
            var validation = _validator.Validate(basicSalaryViewModel);
            if (validation.IsValid)
            {
                var result = await _basicSalaryService.AddBasicSalaryAsync(basicSalaryViewModel);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Fail Add BasicSalary");
                }
            }
            return BadRequest("Invalid Information BasicSalary");
        }

        [HttpPut("{basicSalaryId}")]
        public async Task<IActionResult> UpdateBasicSalaryAsync(int basicSalaryId, BasicSalaryViewModel basicSalaryViewModel)
        {
            var validation = _validator.Validate(basicSalaryViewModel);
            if (validation.IsValid)
            {
                var result = await _basicSalaryService.UpdateBasicSalaryAsync(basicSalaryId, basicSalaryViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information BasicSalary");

        }

        [HttpDelete("{basicSalaryId}")]
        public async Task<IActionResult> DeleteBasicSalaryAsync(int basicSalaryId)
        {
            var result = await _basicSalaryService.RemoveBasicSalaryAsync(basicSalaryId);
            return Ok(result);
        }
    }
}
