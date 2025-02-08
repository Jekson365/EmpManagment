using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MyApp.Models;

namespace MyApp.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("name should not be empty!")
                .MaximumLength(12).WithMessage("max length for name is 12")
                .MinimumLength(1).WithMessage("min lenfth for name is 1");
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("surname is empty!!!")
                .MaximumLength(15).WithMessage("surname is long");
        }
    }
}