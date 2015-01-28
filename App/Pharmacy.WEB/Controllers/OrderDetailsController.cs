using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using Pharmacy.Contracts.Manager;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModelCreator;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IManager<OrderDetails> _orderManager;
        private readonly IManager<Medcine> _medcineManager;
        private readonly OrderDetailsViewModelCreator _modelCreator;

        public OrderDetailsController(IManager<OrderDetails> orderManager, 
            OrderDetailsViewModelCreator modelCreator, 
            IManager<Medcine> medcineManager)
        {
            _orderManager = orderManager;
            _modelCreator = modelCreator;
            _medcineManager = medcineManager;
        }

        // GET: OrderDetails/Create
        public ActionResult Create(int orderId)
        {
            var model = _modelCreator.GetDetailsModel(orderId);
            return View(model);
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetailsViewModel model)
        {
            try
            {
                if(!ModelState.IsValid) return View(_modelCreator.GetDetailsModel(model.OrderId));
                var order = Mapper.Map<OrderDetailsViewModel, OrderDetails>(model);
                _orderManager.Add(order);
                return RedirectToRoutePermanent("OrderDetails", new { id = model.OrderId });
            }
            catch
            {
                return View(_modelCreator.GetDetailsModel(model.OrderId));
            }
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int orderId, int medcineId)
        {
            var model = _modelCreator.GetDetailsModel(orderId, medcineId);
            return View(model);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int orderId, int medcineId, OrderDetailsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(_modelCreator.GetDetailsModel(orderId, medcineId));
                var order = _orderManager.GetByPrimaryKey(orderId, medcineId);
                order = Mapper.Map(model, order);
                _orderManager.Update(order);
                return RedirectToRoutePermanent("OrderDetails", new { id = model.OrderId });
            }
            catch
            {
                return View(_modelCreator.GetDetailsModel(orderId, medcineId));
            }
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int orderId, int medcineId)
        {
            var model = _modelCreator.GetDetailsModel(orderId, medcineId);
            return View(model);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int orderId, int medcineId, OrderDetailsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(_modelCreator.GetDetailsModel(orderId, medcineId));
                _orderManager.Remove(orderId, medcineId);
                return RedirectToRoutePermanent("OrderDetails", new { id = model.OrderId });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetPrice(int medcineId)
        {
            var price = _medcineManager.GetByPrimaryKey(medcineId).Price;
            return Json(new {
                Price = price
            },
            JsonRequestBehavior.AllowGet);
        } 
    }
}
