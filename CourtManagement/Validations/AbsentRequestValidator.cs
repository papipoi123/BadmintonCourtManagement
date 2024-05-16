using Applications.ViewModels.AbsentRequestViewModels;
using Applications.ViewModels.BasicSalaryViewModels;
using Domain.Enums.Status;
using FluentValidation;

namespace APIs.Validations
{
    public class AbsentRequestValidator : AbstractValidator<AbsentRequestViewModel>
    {
        public AbsentRequestValidator()
        {
            RuleFor(x => x.absentReason).NotEmpty();
            RuleFor(x => x.reportStatus).NotEmpty();
            RuleFor(x => x.requestType).NotEmpty();
            RuleFor(x => x.date).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
        }
    }
}