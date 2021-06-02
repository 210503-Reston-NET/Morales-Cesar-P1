using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreModels;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ManagerController : Controller
    {
        // GET: ManagerController


        private IBusLog _Buslog;
        public ManagerController(IBusLog bus)
        {
            _Buslog = bus;
        }
        public ActionResult Index()
        {
            List<Product> products = _Buslog.GetAllProducts();
            List<Storefront> storefronts = _Buslog.GetAllStorefronts();
            foreach(var prods in products)
            {
                foreach(var strf in storefronts)
                {
                    if(_Buslog.GetInventory(prods.ProductCode,strf.storeID)==null)
                    {
                        Random nums = new Random();
                        int ID = nums.Next(100,999);
                        Inventory newInventory = new Inventory(ID, 0, prods.ProductCode, strf.storeID);
                        InventoryVM newInventory1 = new InventoryVM(newInventory);

                        _Buslog.AddInventory(newInventory);
                    }
                }
            }
            return View(_Buslog.GetAllManagers().Select(manag => new ManagerVM(manag)).ToList());
        }
        public ActionResult ReplenishInventoryStore()
        {
            return View(_Buslog.GetAllStorefronts().Select(store => new StorefrontVM(store)).ToList());
        }
        public ActionResult ReplenishInventoryProduct(int store)
        {
            ViewBag.Storefront = _Buslog.GetStorefront3(store);
            return View(_Buslog.GetAllProducts().Select(store => new ProductVM(store)).ToList());
        }

        public ActionResult CreateItem(ProductVM productVM)
        {
            try
            {
                if (ModelState.IsValid)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStorefront(StorefrontVM storefrontVM)
        {

            //GET THIS TO WORK SUNDAY!!!
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

        public ActionResult UpdateInventory(int store, int prods)
        {
            return View(new InventoryVM(_Buslog.GetInventory(store,prods)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInventory(int store, int prods, InventoryVM inventoryVM)
        {
            try
            {

                Inventory red = new Inventory(inventoryVM.inventoryid, inventoryVM.inventoryQuantity, inventoryVM.inventoryName, inventoryVM.storeId);
                _Buslog.UpdateInventory(red);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagerVM manager)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Buslog.AddManager(new Manager
                    {

                        name = manager.name,
                        ID = manager.Id,
                        
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

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
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

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
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
