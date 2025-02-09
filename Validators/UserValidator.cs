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
                .Length(1, 15).WithMessage("name length should be between  1 and 15");
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("surname is empty!!!")
                .Length(1, 20).WithMessage("surname field should be between 1 and 20");
            RuleFor(p => p.Age)
                .InclusiveBetween(18, 60);
        }
    }
}