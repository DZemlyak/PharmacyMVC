using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.Validators
{
    class StorageEditViewModelValidator : AbstractValidator<StorageEditViewModel>
    {
        public StorageEditViewModelValidator()
        {
            RuleFor(p => p.Count)
                .NotEmpty().WithMessage("Must be positive number!")
                .GreaterThan(0).WithMessage("Must be positive number!");
        }

    }
}
