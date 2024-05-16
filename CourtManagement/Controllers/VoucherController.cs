using Applications.Interfaces;
using Applications.ViewModels.Voucher;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        private readonly IValidator<VoucherViewModel> _validator;

        public VoucherController(IVoucherService voucherService, IValidator<VoucherViewModel> validator)
        {
            _voucherService = voucherService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVoucher(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _voucherService.GetAllVoucherAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVoucher(VoucherViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _voucherService.CreateVoucherAsync(model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVoucher(int id, VoucherViewModel model)
        {
            var valid = _validator.Validate(model);
            if (valid.IsValid)
            {
                var result = await _voucherService.UpdateVoucherAsync(id, model);
                return Ok(result);
            }
            return BadRequest("Invalid infomation");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var result = await _voucherService.DeleteVoucherAsync(id);
            return Ok(result);
        }
    }
}
