using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.Validators
{
    class StorageViewModelValidator : AbstractValidator<StorageViewModel>
    {
        public StorageViewModelValidator()
        {
            RuleFor(p => p.MedcineId)
                .GreaterThan(0);
            RuleFor(p => p.PharmacyId)
                .GreaterThan(0);
            RuleFor(p => p.Count)
                .GreaterThan(0);
        }
    }
}
