using FluentValidation;
using NetNix.MVC.Models;

namespace NetNix.MVC.FluentValidations
{
    public class LikeBodyValidations : AbstractValidator<LikeBodyViewModel>
    {
        public LikeBodyValidations()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MovieId).NotEmpty();            
        }
    }
}
