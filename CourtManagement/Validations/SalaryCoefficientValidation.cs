using Applications.ViewModels.SalaryCoefficientViewModels;
using FluentValidation;

namespace APIs.Validations
{
    public class SalaryCoefficientValidation : AbstractValidator<SalaryCoefficientViewModel>
    {
        public SalaryCoefficientValidation() 
        {
            RuleFor(x => x.coefficientName).NotEmpty();
            RuleFor(x => x.coefficientForHour).NotEmpty();
        }    
    }
}
