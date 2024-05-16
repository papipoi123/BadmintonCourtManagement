using Applications.ViewModels.StaffWorkingProfileViewModels;
using FluentValidation;

namespace APIs.Validations
{
	public class StaffWorkingProfileValidation : AbstractValidator<StaffWorkingProfileViewModel>
	{
		public StaffWorkingProfileValidation()
		{
			RuleFor(x => x.totalAbsent).NotEmpty();
			RuleFor(x => x.totalPresent).NotEmpty();
			RuleFor(x => x.retireStatus).NotEmpty();
			RuleFor(x => x.totalSalary).NotEmpty();
			RuleFor(x => x.userId).NotEmpty();
		}
	}
}
