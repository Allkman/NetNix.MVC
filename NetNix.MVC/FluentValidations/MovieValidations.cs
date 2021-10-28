using FluentValidation;
using NetNix.MVC.Models;

namespace NetNix.MVC.FluentValidations
{
    public class MovieValidations : AbstractValidator<MovieViewModel>
    {
        public MovieValidations()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ReleaseDate).NotEmpty();
            RuleFor(x => x.Director).NotEmpty();            
        }
    }
}
