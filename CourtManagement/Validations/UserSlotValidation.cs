using Applications.ViewModels.UserSlotViewModels;
using FluentValidation;

namespace APIs.Validations
{
    public class UserSlotValidation : AbstractValidator<UserSlotViewModel>
    {
        public UserSlotValidation()
        {
            RuleFor(x => x.workingSlotInAMonthId).NotEmpty().NotNull();
            RuleFor(x => x.userId).NotEmpty().NotNull();
        }
    }
}
