using Applications.Interfaces;
using Applications.Services;
using Applications.ViewModels.Payment;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IValidator<PaymentViewModel> _validator;

        public PaymentController(IPaymentService paymentService, IValidator<PaymentViewModel> validator)
        {
            _paymentService = paymentService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayment(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _paymentService.GetAllPaymentAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _paymentService.CreatePaymentAsync(model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment(int id, PaymentViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _paymentService.UpdatePaymentAsync(id, model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);
            return Ok(result);
        }
    }
}
