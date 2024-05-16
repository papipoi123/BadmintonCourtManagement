using Applications.ViewModels.Payment;
using FluentValidation;

namespace APIs.Validations
{
    public class PaymentValidation : AbstractValidator<PaymentViewModel>
    {
        public PaymentValidation()
        {
            RuleFor(x => x.paymentType).NotEmpty();
        }
    }
}
