using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.Validators
{
    public class OrderDetailsViewModelValidator : AbstractValidator<OrderDetailsViewModel>
    {
        public OrderDetailsViewModelValidator()
        {
            RuleFor(p => p.Count)
                .NotEmpty().WithMessage("Field value is not valid!")
                .GreaterThanOrEqualTo(0).WithMessage("Must be positve number!");
        }

    }
}
