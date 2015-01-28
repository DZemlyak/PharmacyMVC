using System.Collections.Generic;
using System.Web.Mvc;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Core.ViewModelCreator
{
    public class StorageViewModelCreator
    {
        private readonly IManager<Medcine> _medcineManager;
        private readonly IManager<Pharmacy.Core.Pharmacy> _pharmacyManager;

        public StorageViewModelCreator(IManager<Medcine> medcineManager,
            IManager<Pharmacy.Core.Pharmacy> pharmacyManager) {
            _medcineManager = medcineManager;
            _pharmacyManager = pharmacyManager;
        }

        public StorageEditViewModel GetCreateModel()
        {
            var model = new StorageEditViewModel {
                MedcineItems = new List<SelectListItem>(),
                PharmacyItems = new List<SelectListItem>()
            };
            foreach (var item in _medcineManager.GetAll()) {
                model.MedcineItems.Add(new SelectListItem {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            foreach (var item in _pharmacyManager.GetAll()) {
                model.PharmacyItems.Add(new SelectListItem {
                    Text = item.Number.ToString(),
                    Value = item.Id.ToString()
                });
            }
            return model;
        }

        public StorageEditViewModel GetEditModel(Storage entity)
        {
            var model = new StorageEditViewModel {
                MedcineItems = new List<SelectListItem>(),
                PharmacyItems = new List<SelectListItem>(),
                Count = entity.Count
            };
            model.MedcineItems.Add(new SelectListItem {
                Text = entity.Medcine.Name,
                Value = entity.MedcineId.ToString()
            });
            model.PharmacyItems.Add(new SelectListItem {
                Text = entity.Pharmacy.Number.ToString(),
                Value = entity.PharmacyId.ToString()
            });
            return model;
        }
    }
}
