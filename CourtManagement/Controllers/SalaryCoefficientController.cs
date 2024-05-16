using Applications.Interfaces;
using Applications.Services;
using Applications.ViewModels.SalaryCoefficientViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Applications.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCoefficientController : ControllerBase
    {
        private readonly ISalaryCoefficientService _salaryCoefficientService;
        private readonly IValidator<SalaryCoefficientViewModel> _validator;

        public SalaryCoefficientController(ISalaryCoefficientService salaryCoefficientService, IValidator<SalaryCoefficientViewModel> validator)
        {
            _salaryCoefficientService = salaryCoefficientService;
            _validator = validator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalaryCoefficientAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _salaryCoefficientService.GetAllSalaryCoefficientAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalaryCoefficientAsync(SalaryCoefficientViewModel salaryCoefficientViewModel)
        {
            var valid = _validator.Validate(salaryCoefficientViewModel);
            if (valid.IsValid)
            {
                var result = await _salaryCoefficientService.AddSalaryCoefficientAsync(salaryCoefficientViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information SalaryCoefficient");
        }

        [HttpPut("{SalaryCoefficientId}")]
        public async Task<IActionResult> UpdateHolidatAsync(int SalaryCoefficientId, SalaryCoefficientViewModel salaryCoefficientViewModel)
        {
            var valid = _validator.Validate(salaryCoefficientViewModel);
            if (valid.IsValid)
            {
                var result = await _salaryCoefficientService.UpdateSalaryCoefficientAsync(SalaryCoefficientId, salaryCoefficientViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information SalaryCoefficient");
        }

        [HttpDelete("{SalaryCoefficientId}")]
        public async Task<IActionResult> DeleteHolidatAsync(int SalaryCoefficientId)
        {
            var result = await _salaryCoefficientService.RemoveSalaryCoefficientAsync(SalaryCoefficientId);
            return Ok(result);

        }

    }
}
