using Applications.ViewModels.WorkingManagement;
using FluentValidation;

namespace APIs.Validations
{
    public class WorkingManagementValidation : AbstractValidator<WorkingManagementViewModel>
    {
        public WorkingManagementValidation()
        {
            RuleFor(x => x.endDate).NotEmpty();
            RuleFor(x => x.startDate).NotEmpty();
        }
    }
}
