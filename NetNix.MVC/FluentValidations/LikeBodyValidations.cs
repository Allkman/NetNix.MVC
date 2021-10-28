using FluentValidation;
using NetNix.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
