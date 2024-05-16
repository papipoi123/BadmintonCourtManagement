using Applications.Interfaces;
using Applications.ViewModels.Court;
using Domain.Enums.Status;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly IValidator<CourtModel> _validator;
        private readonly ICourtService _courtService;
        public CourtController(ICourtService courtService, IValidator<CourtModel> validator)
        {
            _courtService = courtService;
            _validator = validator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var result = await _courtService.GetCourtDetailById(id);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _courtService.GetAllCourt(pageIndex, pageSize);

            return Ok(result);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> Filter(string? code, int? size, decimal? price, AvailableStatus? availableStatus, ReservationStatus? reservationStatus, int pageIndex = 0, int pageSize = 10)
        {
            var result = await _courtService.Filter(code, size, price, availableStatus, reservationStatus, pageIndex, pageSize);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourt([FromBody] CourtModel model)
        {
            var val = _validator.Validate(model);
            if (val.IsValid)
            {
                var result = await _courtService.CreateCourt(model);

                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourt([FromRoute] int id, [FromBody] CourtModel model)
        {
            var val = _validator.Validate(model);
            if (val.IsValid)
            {
                var result = await _courtService.UpdateCourt(id, model);

                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourt([FromRoute] int id)
        {
            var result = await _courtService.DeleteCourt(id);

            return Ok(result);
        }
    }
}
