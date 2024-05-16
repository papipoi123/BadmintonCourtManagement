using Applications.ViewModels.Voucher;
using FluentValidation;

namespace APIs.Validations
{
    public class VoucherValidation : AbstractValidator<VoucherViewModel>
    {
        public VoucherValidation()
        {
            RuleFor(x => x.discountPercent).NotEmpty();
            RuleFor(x => x.voucherName).NotEmpty();
        }
    }
}
