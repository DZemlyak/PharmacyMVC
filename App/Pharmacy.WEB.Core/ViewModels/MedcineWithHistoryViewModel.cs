using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.WEB.Core.ViewModels
{
    public class MedcineWithHistoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<MedcinePriceHistoryViewModel> MedcinePriceHistories { get; set; }
    }
}
