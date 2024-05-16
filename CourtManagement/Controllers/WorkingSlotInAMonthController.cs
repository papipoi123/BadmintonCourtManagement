using Applications.Interfaces;
using Applications.Services;
using Applications.ViewModels.Response;
using Applications.ViewModels.WorkingSlotInAMonth;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingSlotInAMonthController : ControllerBase
    {
        private readonly IWorkingSlotInAMonthService _workingSlotInAMonthService;
        private readonly IValidator<WorkingSlotInAMonthViewModel> _validator;

        public WorkingSlotInAMonthController(IWorkingSlotInAMonthService workingSlotInAMonthService, IValidator<WorkingSlotInAMonthViewModel> validator)
        {
            _workingSlotInAMonthService = workingSlotInAMonthService;
            _validator = validator;
        }
        [HttpGet("GetAllWorkingSlotInAMonth")]
        public async Task<IActionResult> Get(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _workingSlotInAMonthService.GetAllWorkingSlotInAMonthAsync(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Filter(DateTime start, DateTime end)
        {
            var result = await _workingSlotInAMonthService.Filter(start, end);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateWorkingSlotInAMonth(WorkingSlotInAMonthViewModel model)
        //{
        //    var valid = _validator.Validate(model);
        //    if (valid.IsValid)
        //    {
        //        var result = await _workingSlotInAMonthService.CreateWorkingSlotInAMonthAsync(model);
        //        return Ok(result);
        //    }
        //    return BadRequest("Invalid infomation");
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateWorkingSlotInAMonth(int id, WorkingSlotInAMonthViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _workingSlotInAMonthService.UpdateWorkingSlotInAMonthAsync(id, model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkingSlotInAMonth(int id)
        {
            var result = await _workingSlotInAMonthService.DeleteWorkingSlotInAMonthAsync(id);
            return Ok(result);
        }
        [HttpPost("CreateListWorkingSlotInAmonth/{startDate}/{endDate}")]
        public async Task<Response> AddListWorkingSlotInAMonth(DateTime startDate,DateTime endDate) => await _workingSlotInAMonthService.AddListWorkingSlotInAMonthAsync(startDate, endDate);

        [HttpGet("GetWorkingSlotInAMonthById/{WksId:int}")]
        public async Task<IActionResult> GetWorkingSlotInAMonthById(int WksId)
        {
            var result = await _workingSlotInAMonthService.GetWorkingSLotInAMonthByID(WksId);
            return Ok(result);
        }
    }
}
