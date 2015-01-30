using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModelCreator;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class StorageController : Controller
    {
        private readonly IManager<Storage> _storageManager;
        private readonly StorageViewModelCreator _storageModelCreator;
        
        public StorageController(IManager<Storage> manager, StorageViewModelCreator modelCreator)
        {
            _storageManager = manager;
            _storageModelCreator = modelCreator;
        }

        // GET: Storage
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Storage>, IEnumerable<StorageViewModel>>(_storageManager.GetAll()));
        }

        // GET: Storage/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = _storageModelCreator.GetCreateModel();
            return View(model);
        }

        // POST: Storage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(StorageEditViewModel storageCreationViewModel)
        {
            try {
                if (!ModelState.IsValid) return View(_storageModelCreator.GetCreateModel());
                _storageManager.Add(Mapper.Map<StorageEditViewModel, Storage>(storageCreationViewModel));
                return RedirectToAction("Index");
            }
            catch {
                return View(_storageModelCreator.GetCreateModel());
            }
        }

        // GET: Storage/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int pharmacyId, int medcineId)
        {
            var entity = _storageManager.GetByPrimaryKey(medcineId, pharmacyId);
            return View(_storageModelCreator.GetEditModel(entity));
        }

        // POST: Storage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int pharmacyId, int medcineId, StorageEditViewModel storageCreationViewModel)
        {
            try
            {
                var entity = _storageManager.GetByPrimaryKey(medcineId, pharmacyId);
                if (!ModelState.IsValid) {
                    return View(_storageModelCreator.GetEditModel(entity));
                }
                entity.Count = storageCreationViewModel.Count;
                _storageManager.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Storage/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int pharmacyId, int medcineId)
        {
            var model = Mapper.Map<Storage, StorageViewModel>(
                _storageManager.GetByPrimaryKey(medcineId, pharmacyId));
            return View(model);
        }

        // POST: Storage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int pharmacyId, int medcineId, FormCollection formCollection)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return View(Mapper.Map<Storage, StorageViewModel>(
                        _storageManager.GetByPrimaryKey(medcineId, pharmacyId)));

                _storageManager.Remove(medcineId, pharmacyId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
