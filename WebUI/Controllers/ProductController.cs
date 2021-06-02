using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusLog;
using StoreModels;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IBusLog _Buslog;
        public ProductController(IBusLog bus)
        {
            _Buslog = bus;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_Buslog.GetAllProducts().Select(prod => new ProductVM(prod)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM productVM)
        {
            try
            {   
                 if(ModelState.IsValid)
                {
                    _Buslog.AddProduct(new Product
                    {

                        ProductName = productVM.productname,
                        ProductPrice = productVM.productprice,
                        ProductCode = productVM.productcode,
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
