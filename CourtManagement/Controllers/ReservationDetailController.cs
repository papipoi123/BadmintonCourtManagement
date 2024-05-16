using Applications.Interfaces;
using Applications.ViewModels.ReservationDetailViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDetailController : ControllerBase
    {
        private readonly IReservationDetailService _reservationDetailService;
        private readonly IValidator<ReservationDetailViewModel> _validator;

        public ReservationDetailController(IReservationDetailService reservationDetailService, IValidator<ReservationDetailViewModel> validator)
        {
            _reservationDetailService = reservationDetailService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _reservationDetailService.GetAllReservationDetailAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int courtId, int reservationId)
        {
            var result = await _reservationDetailService.CreateReservationDetailAsync(courtId, reservationId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int courtId, int reservationId, ReservationDetailViewModel reservationDetailViewModel)
        {
            var validate = _validator.Validate(reservationDetailViewModel);
            if (validate.IsValid)
            {
                var result = await _reservationDetailService.UpddateReservationDetailAsync(courtId, reservationId, reservationDetailViewModel);
                return Ok(result);
            }
            return BadRequest("Invalid Information");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int reservationId)
        {
            var result = await _reservationDetailService.DeleteReservationDetailAsync(reservationId);
            return Ok(result);
        }
    }
}
