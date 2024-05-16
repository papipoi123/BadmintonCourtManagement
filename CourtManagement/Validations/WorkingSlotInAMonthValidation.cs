using Applications.ViewModels.WorkingSlotInAMonth;
using FluentValidation;

namespace APIs.Validations
{
    public class WorkingSlotInAMonthValidation : AbstractValidator<WorkingSlotInAMonthViewModel>
    {
        public WorkingSlotInAMonthValidation()
        {
            RuleFor(x => x.startTime).NotEmpty();
            RuleFor(x => x.endTime).NotEmpty();
            RuleFor(x => x.slotHour).NotEmpty();
            RuleFor(x => x.slotSalary).NotEmpty();
            RuleFor(x => x.workingStatus).NotEmpty();
        }
    }
}
