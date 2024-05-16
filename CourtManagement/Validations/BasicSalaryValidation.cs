using Applications.ViewModels.BasicSalaryViewModels;
using FluentValidation;

namespace APIs.Validations
{
	public class BasicSalaryValidation : AbstractValidator<BasicSalaryViewModel>
	{
		public BasicSalaryValidation() 
		{
			RuleFor(x => x.basicSalary).NotEmpty();
		}
	}
}
