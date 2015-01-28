using FluentValidation;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.Validators
{
    class MedcineViewModelValidator : AbstractValidator<MedcineViewModel>
    {
        public MedcineViewModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Field cant't be empty!");
            RuleFor(p => p.SerialNumber)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Matches(@"...-...-..").WithMessage("Wrong serial number! (ex. \"000-000-00\")");
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Length(0, 250);
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .GreaterThan(0).WithMessage("Can't be negative!");
        }
    }
}
