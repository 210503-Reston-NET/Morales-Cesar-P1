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
    public class CustomerController : Controller
    {
        // GET: CustomerController

        private IBusLog _Buslog;
        public CustomerController(IBusLog bus)
        {
            _Buslog = bus;
        }
        public ActionResult Index()
        {
            return View(_Buslog.GetAllCustomers().Select(cust => new CustomerVM(cust)).ToList());
        }

        public ActionResult OrderItemStore(int cust)
        {
            ViewBag.Customer = _Buslog.GetCustomer3(cust);
            return View(_Buslog.GetAllStorefronts().Select(store => new StorefrontVM(store)).ToList());
        }
        //STILL NEED TO EDIT THIS PART 
        public ActionResult OrderStoreItem(int cust, int store)
        {
            Random nums = new Random();
            int IDs = nums.Next(1000, 9999);
            Order orde = new Order(IDs, store, 0, cust);
            ViewBag.Customer = _Buslog.GetCustomer3(cust);
            ViewBag.Storefront = _Buslog.GetStorefront3(store);
           
            _Buslog.AddOrder(new Order
            {

                IDs = orde.IDs,
                Storefrontsss = orde.Storefrontsss,
                Total = orde.Total,
                customernumber = orde.customernumber,

            }
            );
            ViewBag.Order = _Buslog.GetOrder3(IDs);
            
            return View(_Buslog.GetAllProducts().Select(prod => new ProductVM(prod)).ToList());
        }
        //STILL NEED TO CREATE VIEWS OF THIS
        public ActionResult BuyItem(int cust, int store, int prod, int orde)
        {
            //NEED TO FIX THIS TOMMORROW... DOUBLE TRACING ON INVENTORY AND ORDER...


            ViewBag.Customer = _Buslog.GetCustomer3(cust);
            ViewBag.Storefront = _Buslog.GetStorefront3(store);
            ViewBag.Order = _Buslog.GetOrder3(orde);
            ViewBag.Product = _Buslog.GetProduct3(prod);
            ViewBag.Inventory = _Buslog.GetInventory(store, prod);
            int five = orde;
            if(ViewBag.Inventory.InventoryQuantity != 0 )
            {
                Random nums = new Random();
                int ID = nums.Next(100, 999);
                LineItem lineItem = new LineItem(ID, 1, orde, prod);
                _Buslog.AddLineItem(lineItem);
              

                _Buslog.UpdateInventories(store,prod);
                
                _Buslog.UpdateOrders(five, ViewBag.Product.ProductPrice);
                
                return View(new LineItemVM(lineItem));
            }

            return View();
            
            
        }

        public ActionResult OrderStoreItem2(int cust, int store, int orde)
        {
            //THIS IS DONE AND READY TO TEST OUT
            ViewBag.Customer = _Buslog.GetCustomer3(cust);
            ViewBag.Storefront = _Buslog.GetStorefront3(store);
            ViewBag.Order = _Buslog.GetOrder3(orde);
            
            
            return View(_Buslog.GetAllProducts().Select(store => new ProductVM(store)).ToList());
        }

     

        public ActionResult OrderPlaced(int cust, int store, int orde)
        {
            List<LineItem> LIList = _Buslog.GetLineItemsById(orde); 

            //THIS NEEDS SOME FIXING
            ViewBag.Customer = _Buslog.GetCustomer3(cust);
            ViewBag.Storefront = _Buslog.GetStorefront3(store);
            ViewBag.Order = _Buslog.GetOrder3(orde);
            //foreach(var items in LIList)
            //{
                //return View(new LineItemVM(items));
            //}
            
            return View(_Buslog.GetLineItemsById(orde).Select(stores => new LineItemVM(stores)).ToList());

        }


        //NEED TO WORK THIS OUT







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
        public ActionResult Create(CustomerVM customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Buslog.AddCustomer(new Customer
                    {

                        name = customer.name,
                        hometown = customer.hometown,

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
