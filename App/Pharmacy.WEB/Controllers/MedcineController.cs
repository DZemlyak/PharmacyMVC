using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedcineController : Controller
    {
        private readonly IManager<Medcine> _manager;

        public MedcineController(IManager<Medcine> manager)
        {
            _manager = manager;
        }

        // GET: Medcine
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Medcine>, 
                IEnumerable<MedcineViewModel>>(_manager.GetAll()));
        }

        // GET: Medcine/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Medcine, MedcineWithHistoryViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // GET: Medcine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medcine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedcineViewModel medcineViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(medcineViewModel);
                _manager.Add(Mapper.Map<MedcineViewModel, Medcine>(medcineViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medcine/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Medcine, MedcineViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Medcine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedcineViewModel medcineViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(medcineViewModel);
                var medcine = _manager.GetByPrimaryKey(id);
                medcine = Mapper.Map<MedcineViewModel, Medcine>(medcineViewModel, medcine);
                _manager.Update(medcine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medcine/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Medcine, MedcineViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Medcine/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MedcineViewModel medcineViewModel)
        {
            try
            {
                _manager.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
