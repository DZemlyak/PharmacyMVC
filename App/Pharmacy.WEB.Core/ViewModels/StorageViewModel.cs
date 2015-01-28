using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.WEB.Core.Validators;
using FluentValidation.Attributes;
using Pharmacy.Core;

namespace Pharmacy.WEB.Core.ViewModels
{
    [Validator(typeof(StorageViewModelValidator))]
    public class StorageViewModel
    {
        public int PharmacyId { get; set; }
        public int MedcineId { get; set; }
        [Display(Name = "Medcine Name")]
        public string MedcineName { get; set; }
        [Display(Name = "Pharmacy Number")]
        public string PharmacyNumber { get; set; }
        public int Count { get; set; }
        public List<Medcine> MedcineList { get; set; } 
    }
}
