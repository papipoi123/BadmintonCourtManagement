using Applications.ViewModels.FurloughViewModels;
using FluentValidation;

namespace APIs.Validations
{
    public class FurloughValidation : AbstractValidator<FurloughViewModel>
    {
        public FurloughValidation()
        {
            RuleFor(x => x.remainFurlough).NotEmpty();
            RuleFor(x => x.usedFurlough).NotEmpty();
            RuleFor(x => x.totalFurloughDay).NotEmpty();
            RuleFor(x => x.userId).NotEmpty();
        }
    }
}
