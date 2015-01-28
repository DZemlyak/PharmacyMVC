using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Pharmacy.WEB.Core.Validators;

namespace Pharmacy.WEB.Core.ViewModels
{
    [Validator(typeof(MedcineViewModelValidator))]
    public class MedcineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
