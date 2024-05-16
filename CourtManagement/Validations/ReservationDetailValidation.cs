using Applications.ViewModels.ReservationDetailViewModels;
using FluentValidation;

namespace APIs.Validations
{
    public class ReservationDetailValidation : AbstractValidator<ReservationDetailViewModel>
    {
        public ReservationDetailValidation()
        {
            RuleFor(x => x.ReservationId).NotEmpty().NotNull();
            RuleFor(x => x.CourtId).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotEmpty().NotNull();
        }
    }
}
