using Applications.Interfaces;
using Applications.ViewModels.AbsentRequestViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsentRequestController : ControllerBase
    {
        private readonly IAbsentRequestService _AbsentRequestService;
        private readonly IValidator<AbsentRequestViewModel> _validator;

        public AbsentRequestController(IAbsentRequestService AbsentRequestService, IValidator<AbsentRequestViewModel> validator)
        {
            _AbsentRequestService = AbsentRequestService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbsentRequestAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _AbsentRequestService.GetAllAbsentRequestAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbsentRequestAsync(AbsentRequestViewModel AbsentRequestViewModel)
        {
            var validation = _validator.Validate(AbsentRequestViewModel);
            if (validation.IsValid)
            {
                var result = await _AbsentRequestService.AddAbsentRequestAsync(AbsentRequestViewModel);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Fail Add AbsentRequest");
                }
            }
            return BadRequest("Invalid Information AbsentRequest");
        }

        [HttpPut("{AbsentRequestId}")]
        public async Task<IActionResult> UpdateAbsentRequestAsync(int AbsentRequestId, AbsentRequestViewModel AbsentRequestViewModel)
        {
            var validation = _validator.Validate(AbsentRequestViewModel);
            if (validation.IsValid)
            {
                var result = await _AbsentRequestService.UpdateAbsentRequestAsync(AbsentRequestId, AbsentRequestViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information AbsentRequest");

        }

        [HttpDelete("{AbsentRequestId}")]
        public async Task<IActionResult> DeleteAbsentRequestAsync(int AbsentRequestId)
        {
            var result = await _AbsentRequestService.RemoveAbsentRequestAsync(AbsentRequestId);
            return Ok(result);
        }
    }
}
