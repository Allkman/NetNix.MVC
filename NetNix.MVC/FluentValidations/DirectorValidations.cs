using FluentValidation;
using NetNix.MVC.Models;

namespace NetNix.MVC.FluentValidations
{
    public class DirectorValidations : AbstractValidator<DirectorViewModel>
    {
        public DirectorValidations()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
