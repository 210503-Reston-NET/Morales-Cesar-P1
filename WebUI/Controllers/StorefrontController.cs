using BusLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StorefrontController : Controller
    {
        private IBusLog _Buslog;
        public StorefrontController(IBusLog bus)
        {
            _Buslog = bus;
        }
        // GET: StorefrontController
        public ActionResult Index()
        {
            return View(_Buslog.GetAllStorefronts().Select(store => new StorefrontVM(store)).ToList());
                
 
        }

        // GET: StorefrontController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StorefrontController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StorefrontController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StorefrontVM storefrontVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Buslog.AddStorefront(new Storefront
                    {

                        storeID = storefrontVM.ID,
                        Town = storefrontVM.Name
                    }

                    );

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StorefrontController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StorefrontController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StorefrontController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StorefrontController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
