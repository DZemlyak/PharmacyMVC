using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.ViewModelCreator
{
    public class OrderDetailsViewModelCreator
    {
        private readonly IManager<Medcine> _medcineManager;
        private readonly IManager<OrderDetails> _orderDManager;

        public OrderDetailsViewModelCreator(IManager<Medcine> medcineManager, IManager<OrderDetails> orderDManager)
        {
            _medcineManager = medcineManager;
            _orderDManager = orderDManager;
        }

        public OrderDetailsViewModel GetDetailsModel(int orderId, int medcineId = 0) {
            var model = new OrderDetailsViewModel {OrderId = orderId};
            if (medcineId != 0) 
                SetPharmacy(model, medcineId);
            else
                SetPharmacyList(model);
            return model;
        }

        private void SetPharmacyList(OrderDetailsViewModel model) {
            model.MedcineItems = new List<SelectListItem>();
            foreach (var item in _medcineManager.GetAll()) {
                model.MedcineItems.Add(new SelectListItem {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
        }

        private void SetPharmacy(OrderDetailsViewModel model, int medcineId) {
            var order = _orderDManager.GetByPrimaryKey(model.OrderId, medcineId);
            model.MedcineItems = new List<SelectListItem>();
            model.Count = order.Count;
            model.UnitPrice = order.UnitPrice;
            model.MedcineItems.Add(new SelectListItem {
                Text = order.Medcine.Name,
                Value = order.Medcine.Id.ToString()
            });
        }
    }
}
