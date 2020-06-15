using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessRulesEngine.Controllers
{
    // Shipping Order Controller
    // Get the Business Reference methods to do the operations
    public class ShippingOrderController : Controller
    {
        // GET: ShippingOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShippingOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShippingOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippingOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}