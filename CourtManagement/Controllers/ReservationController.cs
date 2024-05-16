using Applications.Interfaces;
using Applications.ViewModels.Reservation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IValidator<ReservationViewModel> _validator;

        public ReservationController(IReservationService reservationService, IValidator<ReservationViewModel> validator)
        {
            _reservationService = reservationService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservation(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _reservationService.GetAllPaymentAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _reservationService.CreatePaymentAsync(model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(int id, ReservationViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _reservationService.UpdatePaymentAsync(id, model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var result = await _reservationService.DeletePaymentAsync(id);
            return Ok(result);
        }
    }
}
