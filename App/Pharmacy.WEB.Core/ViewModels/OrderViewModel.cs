using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Pharmacy.Core;

namespace Pharmacy.WEB.Core.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Pharmacy Number")]
        public string PharmacyNumber { get; set; }

        public OperationType Type { get; set; }

        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        
    }
}
