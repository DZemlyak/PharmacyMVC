using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.Validators
{
    public class PharmacyViewModelValidator : AbstractValidator<PharmacyViewModel>
    {
        public PharmacyViewModelValidator()
        {
            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Length(2, 50).WithMessage("Address can't be that length!");
            RuleFor(p => p.Number)
                .NotNull().WithMessage("Field cant't be empty!")
                .GreaterThan(0).WithMessage("Can't be negative!");
            RuleFor(p => p.OpenDate).NotEmpty().WithMessage("Field cant't be empty!");
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Matches(@"^((38|\+38)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")
                .WithMessage("Field doesn't match!");
        }
    }
}
