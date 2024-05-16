using Applications.ViewModels.UserViewModels;
using FluentValidation;

namespace APIs.Validations
{
    public class UserValidation : AbstractValidator<CreateUserViewModel>
    {
        public UserValidation()
        {
            RuleFor(u => u.email)
                .MaximumLength(50)
                .EmailAddress();
            RuleFor(u => u.password)
                .NotEmpty()
                .NotNull()
                .WithMessage("{password} should be not empty!")
                .MinimumLength(5);
            RuleFor(u => u.userName)
                .NotEmpty()
                .NotNull()
                .Must(IsValidUserName)
                .WithMessage("{userName} should be all letters");
            RuleFor(u => u.DOB)
                .NotEmpty()
                .NotNull()
                .WithMessage("{password} should be not empty!");
            RuleFor(u => u.gender).IsInEnum();
        }

        private bool IsValidUserName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
