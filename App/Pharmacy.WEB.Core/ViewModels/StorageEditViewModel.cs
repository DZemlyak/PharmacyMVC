using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using System.Web.Mvc;
using Pharmacy.WEB.Core.Validators;

namespace Pharmacy.WEB.Core.ViewModels
{
    [Validator(typeof(StorageEditViewModelValidator))]
    public class StorageEditViewModel
    {
        [Display(Name = "Pharmacy number list")]
        public int SelectedPharmacyList { get; set; }
        public List<SelectListItem> PharmacyItems { get; set; }

        [Display(Name = "Medcine name list")]
        public int SelectedMedcineList { get; set; }
        public List<SelectListItem> MedcineItems { get; set; }

        public int Count { get; set; }
    }
}
