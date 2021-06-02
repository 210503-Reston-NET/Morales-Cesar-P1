
using System;
using System.Collections.Generic;
using DatLog;
using StoreModels;

namespace BusLog
{

    public class BusLogs : IBusLog
    {

        private IRepository _repo;
        public int pin;
        public BusLogs(IRepository repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer customer)
        {

            if (_repo.GetCustomers(customer) != null)
            {
                throw new Exception("Customer already exists... OOFERS");
            }
            return _repo.AddCustomer(customer);
        }

        public Product AddProduct(Product product)
        {

            if (_repo.GetProductss(product.ProductCode) != null)
            {
                throw new Exception("Customer already exists... OOFERS");
            }
            return _repo.AddProduct(product);
        }

        public Storefront AddStorefront(Storefront storefront)
        {

            if (_repo.GetStorefrontss(storefront.storeID) != null)
            {
                throw new Exception("Customer already exists... OOFERS");
            }
            return _repo.AddStorefront(storefront);
        }

        public Inventory AddInventory(Inventory inventory)
        {

            if (_repo.GetInventory(inventory.InventoryId, inventory.StoreId) != null)
            {
                throw new Exception("Customer already exists... OOFERS");
            }
            return _repo.AddInventory(inventory);
        }

        public Manager AddManager(Manager manager)
        {

            if (_repo.GetManager(manager) != null)
            {
                throw new Exception("Customer already exists... OOFERS");
            }
            return _repo.AddManager(manager);
        }

        public Manager GetManager(Manager manager)
        {
            return _repo.GetManagerss(manager.ID);
        }


        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
        public List<Storefront> GetAllStorefronts()
        {
            return _repo.GetAllStorefronts();
        }
        public List<Inventory> GetAllInventories()
        {
            return _repo.GetAllInventories();
        }

        public List<Manager> GetAllManagers()
        {
            return _repo.GetAllManagers();
        }

        public Customer GetCustomer(Customer customer)
        {
            return _repo.GetCustomer(customer);
        }

        public Customer GetCustomer3(int pin)
        {
           
            return _repo.GetCustomerss(pin);
        }

        public bool GetCustomerT(int pin)
        {
           
            return _repo.GetCustomerT(pin);
        }

        public bool GetManagerT(int pin)
        {
           
            return _repo.GetManagerT(pin);
        }


        public bool GetProductT(int pin)
        {
           
            return _repo.GetProductT(pin);
        }
        public bool GetStorefrontT(int pin)
        {
           
            return _repo.GetStorefrontT(pin);
        }

        public bool GetOrderT(int pin)
        {
           
            return _repo.GetOrderT(pin);
        }


        public Storefront GetStorefront3(int pin)
        {
               return _repo.GetStorefrontss(pin);
        }
           
        public Product GetProduct3(int pin)
        {
            return _repo.GetProductss(pin);
        }  
        

        public Manager GetManager3 (int pin)
        {
            return _repo.GetManagerss(pin);
        }

        public Order GetOrder3 (int pin)
        {
            return _repo.GetOrderss(pin);
        }
        public Customer GetCustomer2(Customer customer)
        {
            return _repo.GetCustomers(customer);
        }


        
            public Order AddOrder(Order order)
            {  
              return _repo.AddOrder(order);
            }

            public Order GetOrder(int id, int cust )
            {
                return _repo.GetOrder(id , cust);
            }
        
            public Inventory GetInventory(int id, int cust )
            {
                return _repo.GetInventory(id , cust);
            }

            public Inventory UpdateInventory(Inventory inventory2BeUpdated)
            {
                return _repo.Inventory(inventory2BeUpdated);
            }

            public Order UpdateOrder(Order order2BeUpdated)
            {
                return _repo.UpdateOrder(order2BeUpdated);
            }

            public List<Inventory> GetInventoryById(int nums)
            {
                return _repo.GetInventoryById(nums);
            }

            public List<Order> GetOrderByID(int nums)
            {
                return _repo.GetOrderById(nums);
            }

            public List<LineItem> GetLineItemsById(int nums)
            {
            return _repo.GetLineItemById(nums);        
            }

        public LineItem AddLineItem(LineItem lineItem)
        {

            if (_repo.GetLineItem(lineItem) != null)
            {
                throw new Exception("Line Item already exists... OOFERS");
            }
            return _repo.AddLineItem(lineItem);
        }

        public void UpdateInventories(int store, int prod)
        {
            _repo.UpdateInventories(store, prod);
        }

        public void UpdateOrders(int orde, int prods)
        {
            
            _repo.UpdateOrders(orde, prods);
        }




        /*
            public Inventory AddInventory(Inventory inventory)
            {  
              return _repo.AddInventory(inventory);
            }

            

            public Inventory GetInventory3(int id, int cust )
            {
                return _repo.GetInventoryT(id , cust);
            }


            public LineItem AddLineItem(LineItem lineitem)
            {  
              return _repo.AddLineItem(order);
            }

            public LineItem GetLineItem(int id, int cust )
            {
                return _repo.GetLineItem(id , cust);
            }

            public LineItem GetLineItemy3(int id, int cust)
            {
                return _repo.GetLineItemT(id , cust);
            }









        */






        /*
           public Storefront AddStorefront(Storefront Storefront)
            {  
              return _repo.AddStorefront(Storefront);
            }
           public List<Storefront> GetAllStorefronts()
           {
               return _repo.GetAllStorefronts();
           }

             


           //public Customer AddProduct(Product product)
            //{  
              //return _repo.AddProduct(product);
            //}
           public List<Product> GetAllProducts()
           {
               return _repo.GetAllProducts();
           }

           



           
           public List<Order> GetAllOrders()
           {
               return _repo.GetAllOrders();
           }

          
           */
    }
}