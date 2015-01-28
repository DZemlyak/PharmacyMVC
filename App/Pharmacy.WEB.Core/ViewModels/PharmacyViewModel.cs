using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Pharmacy.WEB.Core.Validators;

namespace Pharmacy.WEB.Core.ViewModels
{
    [Validator(typeof(PharmacyViewModelValidator))]
    public class PharmacyViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Open Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate { get; set; }
         
    }
}
