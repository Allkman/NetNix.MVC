using FluentValidation;
using NetNix.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
