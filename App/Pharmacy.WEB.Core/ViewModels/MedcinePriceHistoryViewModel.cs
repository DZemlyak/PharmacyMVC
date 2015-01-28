using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.WEB.Core.ViewModels
{
    public class MedcinePriceHistoryViewModel
    {
        [Display(Name = "Medcine Name")]
        public string MedcineName { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Price change Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PriceDate { get; set; }

    }
}
