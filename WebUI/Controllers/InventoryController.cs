using BusLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using StoreModels;

namespace WebUI.Controllers
{
    public class InventoryController : Controller
    {
        private IBusLog _Buslog;
        public InventoryController(IBusLog bus)
        {
            _Buslog = bus;
        }
        // GET: InventoryController
      
        
        /*
        
        1:39 5/26/21
        TRYING TO FINISH INVENTORY
        STILL NEED TO ADJUST IVENTORY PER ID
        NEED TO GET PRODUCTS TO APPEAR ON PAGE
        
        */
        
        
        
        
        public ActionResult Index(int id)
        {
            ViewBag.Product = _Buslog.GetProduct3(id);
            List<Product> prod = _Buslog.GetAllProducts();
           


             
                foreach (var prods in prod)
                {
                    if (_Buslog.GetInventory(prods.ProductCode, id) == null)
                    {
                        Random nums = new Random();
                        int ID = nums.Next(1);
                        Inventory newInventory = new Inventory(ID, 0, prods.ProductCode, id);
                        InventoryVM newInventory1 = new InventoryVM(newInventory);

                        _Buslog.AddInventory(newInventory);
                    }
                }
            
            return View(_Buslog.GetAllInventories().Select(store1 => new InventoryVM(store1)).ToList());
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
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
