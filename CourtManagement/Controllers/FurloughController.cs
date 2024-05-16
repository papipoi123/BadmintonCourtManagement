using Applications.Interfaces;
using Applications.ViewModels.FurloughViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurloughController : ControllerBase
    {
        private readonly IFurloughService _FurloughService;
        private readonly IValidator<FurloughViewModel> _validator;

        public FurloughController(IFurloughService FurloughService, IValidator<FurloughViewModel> validator)
        {
            _FurloughService = FurloughService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFurloughAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _FurloughService.GetAllFurloughAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFurloughAsync(FurloughViewModel FurloughViewModel)
        {
            var validation = _validator.Validate(FurloughViewModel);
            if (validation.IsValid)
            {
                var result = await _FurloughService.AddFurloughAsync(FurloughViewModel);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Fail Add Furlough");
                }
            }
            return BadRequest("Invalid Information Furlough");
        }

        [HttpPut("{FurloughId}")]
        public async Task<IActionResult> UpdateFurloughAsync(int FurloughId, FurloughViewModel FurloughViewModel)
        {
            var validation = _validator.Validate(FurloughViewModel);
            if (validation.IsValid)
            {
                var result = await _FurloughService.UpdateFurloughAsync(FurloughId, FurloughViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information Furlough");

        }

        [HttpDelete("{FurloughId}")]
        public async Task<IActionResult> DeleteFurloughAsync(int FurloughId)
        {
            var result = await _FurloughService.RemoveFurloughAsync(FurloughId);
            return Ok(result);
        }
    }
}
