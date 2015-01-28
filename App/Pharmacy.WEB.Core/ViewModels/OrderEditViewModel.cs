using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Pharmacy.Core;

namespace Pharmacy.WEB.Core.ViewModels
{
    public class OrderEditViewModel
    {
        [Display(Name = "Pharmacy number")]
        public int SelectedPharmacyList { get; set; }
        public List<SelectListItem> PharmacyItems { get; set; }

        [Display(Name = "Operation type")]
        public int SelectedType { get; set; }
        public List<SelectListItem> Types { get; set; }

        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
    }
}
