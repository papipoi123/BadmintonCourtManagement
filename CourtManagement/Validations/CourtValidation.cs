using Applications.ViewModels.Court;
using Domain.Enums.Status;
using FluentValidation;

namespace APIs.Validations
{
    public class CourtValidation : AbstractValidator<CourtModel>
    {
        public CourtValidation()
        {
            RuleFor(x => x.CourtCode).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.AvailableStatus).IsInEnum();
            RuleFor(x => x.ReservationStatus).IsInEnum();
        }
    }
}
