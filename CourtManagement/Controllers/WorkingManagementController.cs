using Applications.Interfaces;
using Applications.ViewModels.WorkingManagement;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingManagementController : ControllerBase
    {
        private readonly IWorkingManagementService _workingManagementService;
        private readonly IValidator<WorkingManagementViewModel> _validator;

        public WorkingManagementController(IWorkingManagementService workingManagementService, IValidator<WorkingManagementViewModel> validator)
        {
            _workingManagementService = workingManagementService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _workingManagementService.GetAllWorkingManagementAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkingManagement(WorkingManagementViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _workingManagementService.CreateWorkingManagementAsync(model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkingManagement(int id, WorkingManagementViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _workingManagementService.UpdateWorkingManagementAsync(id, model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkingManagement(int id)
        {
            var result = await _workingManagementService.DeleteWorkingManagementAsync(id);
            return Ok(result);
        }
    }
}
