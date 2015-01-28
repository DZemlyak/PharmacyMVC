using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pharmacy.WEB.Core.Validators;
using FluentValidation.Attributes;

namespace Pharmacy.WEB.Core.ViewModels
{
    [Validator(typeof(OrderDetailsViewModelValidator))]
    public class OrderDetailsViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Medcine ID")]
        public int MedcineId { get; set; }
        [Display(Name = "Medcine name list")]
        public int SelectedMedcineList { get; set; }
        [Display(Name = "Medcine name")]
        public List<SelectListItem> MedcineItems { get; set; }
        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
    }
}
