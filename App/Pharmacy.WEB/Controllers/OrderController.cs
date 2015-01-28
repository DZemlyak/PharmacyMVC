using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModelCreator;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IManager<Order> _manager;
        private readonly OrderViewModelCreator _modelCreator;

        public OrderController(IManager<Order> manager, OrderViewModelCreator modelCreator)
        {
            _manager = manager;
            _modelCreator = modelCreator;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(_manager.GetAll()));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var order = _manager.GetByPrimaryKey(id);
            var model = Mapper.Map<Order, OrderDetailedViewModel>(order);
            return View(model);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var model = _modelCreator.GetCreateModel();
            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderEditViewModel model)
        {
            try
            {
                var entity = Mapper.Map<OrderEditViewModel, Order>(model);
                _manager.Add(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(_modelCreator.GetCreateModel());
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _manager.GetByPrimaryKey(id);
            var model = _modelCreator.GetEditModel(entity);
            return View(model);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEditViewModel model)
        {
            try
            {
                var order = _manager.GetByPrimaryKey(id);
                _manager.Update(Mapper.Map(model, order));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            var order = _manager.GetByPrimaryKey(id);
            var model = Mapper.Map<Order, OrderDetailedViewModel>(order);
            return View(model);
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
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
