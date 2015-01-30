using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Pharmacy.Contracts.Manager;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PharmacyController : Controller
    {
        private readonly IManager<Pharmacy.Core.Pharmacy> _manager;

        public PharmacyController(IManager<Pharmacy.Core.Pharmacy> manager)
        {
            _manager = manager;
        }

        // GET: Pharmacy
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Pharmacy.Core.Pharmacy>,
                            IEnumerable<PharmacyViewModel>>(_manager.GetAll()));
        }

        // GET: Pharmacy/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Pharmacy.Core.Pharmacy, 
                            PharmacyViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // GET: Pharmacy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PharmacyViewModel pharmacyViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(pharmacyViewModel);
                _manager.Add(Mapper.Map<PharmacyViewModel, Pharmacy.Core.Pharmacy>(pharmacyViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pharmacy/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Pharmacy.Core.Pharmacy, 
                            PharmacyViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Pharmacy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PharmacyViewModel pharmacyViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(pharmacyViewModel);
                var pharmacy = _manager.GetByPrimaryKey(id);
                pharmacy = Mapper.Map(pharmacyViewModel, pharmacy);
                _manager.Update(pharmacy);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pharmacy/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Pharmacy.Core.Pharmacy, 
                            PharmacyViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Pharmacy/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try {
                if (!ModelState.IsValid) return View();
                _manager.Remove(id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
