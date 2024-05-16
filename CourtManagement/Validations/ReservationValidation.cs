using Applications.ViewModels.Reservation;
using FluentValidation;

namespace APIs.Validations
{
    public class ReservationValidation : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidation()
        {
            RuleFor(x => x.startTime).NotEmpty();
            RuleFor(x => x.sendTime).NotEmpty();
            RuleFor(x => x.totalPrice).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
        }
    }
}
