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
    public class OrderViewModelCreator
    {
        private readonly IManager<Pharmacy.Core.Pharmacy> _pharmacyManager;

        public OrderViewModelCreator(IManager<Pharmacy.Core.Pharmacy> pharmacyManager)
        {
            _pharmacyManager = pharmacyManager;
        }

        public OrderEditViewModel GetCreateModel() {
            var model = new OrderEditViewModel();
            SetOperationList(model);
            SetPharmacyList(model);
            model.OrderDate = DateTime.Now;
            return model;
        }

        public OrderEditViewModel GetEditModel(Order order) {
            var model = new OrderEditViewModel();
            SetOperationList(model);
            SetPharmacyList(model);

            model.SelectedPharmacyList = order.PharmacyId;
            model.SelectedType = (int) Enum.Parse(typeof (OperationType), order.Type.ToString());
            model.OrderDate = order.OrderDate;
            return model;
        }

        private void SetPharmacyList(OrderEditViewModel model) {
            model.PharmacyItems = new List<SelectListItem>();
            foreach (var item in _pharmacyManager.GetAll()) {
                model.PharmacyItems.Add(new SelectListItem {
                    Text = item.Number.ToString(),
                    Value = item.Id.ToString()
                });
            }
        }

        private void SetOperationList(OrderEditViewModel model) {
            model.Types = new List<SelectListItem>();
            var values = Enum.GetValues(typeof (OperationType)).Cast<int>().ToList();
            var names = Enum.GetNames(typeof (OperationType));
            for(var i = 0; i < values.Count; i++) {
                model.Types.Add(new SelectListItem {
                    Text = names[i],
                    Value = values[i].ToString()
                });
            }
        }
    }
}
