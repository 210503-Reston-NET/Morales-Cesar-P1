using System.Collections.Generic;
using System.Linq;
using StoreModels;
using System;
using Model = StoreModels;
using Microsoft.EntityFrameworkCore.Storage;
//using Entity = DatLog.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatLog
{
    public class RepoDB : IRepository
    {
        private PokestoreDBContext _context;
        
        public RepoDB(PokestoreDBContext context)
        {
            _context = context;
        } 

        public Model.Customer AddCustomer(Model.Customer customer)
        {
            _context.ChangeTracker.Clear();


            _context.Customers.Add(
            new Customer
            {
                name = customer.name,
                ID = customer.ID,
                hometown = customer.hometown,
            }
            );
            _context.SaveChanges();
            return customer;
        }


        public Model.Product AddProduct(Model.Product product)
        {
            _context.ChangeTracker.Clear();


            _context.Products.Add(
            new Product
            {
                
                
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductCode = product.ProductCode,
            }
            );
            _context.SaveChanges();
            return product;
        }

        public Model.Storefront AddStorefront(Model.Storefront storefront)
        {
            _context.ChangeTracker.Clear();

            _context.Storefronts.Add(
            new Storefront
            {
                storeID = storefront.storeID,
                Town = storefront.Town
            }
            );
            _context.SaveChanges();
            return storefront;
        }

        public Model.Manager AddManager(Model.Manager manager)
        {
            _context.ChangeTracker.Clear();


            _context.Managers.Add(
            new Manager
            {
                name = manager.name,
                ID = manager.ID,
            }
            );
            _context.SaveChanges();
            return manager;
        }


        public Model.Inventory AddInventory(Model.Inventory inventory)
        {
            _context.ChangeTracker.Clear();


            _context.Inventories.Add(
            new Inventory
            {
                InventoryId = inventory.InventoryId,
                InventoryQuantity = inventory.InventoryQuantity,
                InventoryName = inventory .InventoryName,
                StoreId = inventory.StoreId
            }
            );
            _context.SaveChanges();
            return inventory;
        }

        public Model.LineItem AddLineItem(Model.LineItem lineItem)
        {
            _context.ChangeTracker.Clear();


            _context.LineItems.Add(
            new LineItem
            {


                itemID= lineItem.itemID,
                Quantity = lineItem.Quantity,
                orderID = lineItem.orderID,
                productID= lineItem.productID,
            }
            );
            _context.SaveChanges();
            return lineItem;
        }

        public Model.Customer GetCustomer(Model.Customer customer)
                {
                    _context.ChangeTracker.Clear();
                    Customer found = _context.Customers.AsNoTracking().FirstOrDefault(custo => custo.ID == customer.ID);  
                    if (found == null) return null;
                    return new Model.Customer(customer.name, found.ID, customer.hometown);
                }

       


        public Model.Customer GetCustomers(Model.Customer customer) // Customer Creation
                {
            _context.ChangeTracker.Clear();
            Customer found = _context.Customers.AsNoTracking().FirstOrDefault(custo => custo.name == customer.name && custo.hometown == customer.hometown);  
                    if (found == null) return null;
                    return new Model.Customer(customer.name, found.ID, customer.hometown);
                }
        public Model.Manager GetManager(Model.Manager manager) // Customer Creation
        {
            _context.ChangeTracker.Clear();
            Manager found = _context.Managers.AsNoTracking().FirstOrDefault(manag => manag.name == manager.name);
            if (found == null) return null;
            return new Model.Manager(found.name, found.ID);
        }

        /// <summary>
        /// All of these enclosed by the summary comments are for True/False scenarios
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public bool GetCustomerT(int pin)         // Login Interface
                {
            _context.ChangeTracker.Clear();
            Customer found = _context.Customers.AsNoTracking().FirstOrDefault(custo => custo.ID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Customer with that PIN");
                        return false;}
                    return true;
                }

                public bool GetManagerT(int pin)         // Login Interface
                {
            _context.ChangeTracker.Clear();
            Manager found = _context.Managers.AsNoTracking().FirstOrDefault(manag => manag.ID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Manager with that PIN");
                        return false;}
                    return true;
                }

                
                public bool GetProductT(int pin)         // Login Interface
                {                                        //ADD PRODUCT ID UPON UNCOMMENTING
            _context.ChangeTracker.Clear();
            Product found = _context.Products.AsNoTracking().FirstOrDefault(produ => produ.ProductCode == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Product with that PIN");
                        return false;}
                    return true;
                }
                public bool GetStorefrontT(int pin)         // Login Interface
                {
            _context.ChangeTracker.Clear();
            //ADD STORE ID UPON UNCOMMENTING
            Storefront found = _context.Storefronts.AsNoTracking().FirstOrDefault(storef => storef.storeID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Store with that PIN");
                        return false;}
                    return true;
                }
                

/// <summary>
/// Everything above this but below the first summary breakoff is a true/false getters
/// Everything below between this and the 3rd summary breakoffs are getters but with an int value 
/// </summary>
/// <param name="pin"></param>
/// <returns></returns>
                
                
                public Customer GetCustomerss(int pin)         // Login Interface
                {
            _context.ChangeTracker.Clear();
            Customer found = _context.Customers.AsNoTracking().FirstOrDefault(custo => custo.ID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Customer with that PIN");
                        return null;}
                    return new Model.Customer(found.name, found.ID, found.hometown);

                }
                public Manager GetManagerss(int pin)
                {
            _context.ChangeTracker.Clear();
            Manager found = _context.Managers.AsNoTracking().FirstOrDefault(manag => manag.ID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Customer with that PIN");
                        return null;}
                    return new Model.Manager(found.name, found.ID);
                }

                public Order GetOrderss(int pin)
                {
            _context.ChangeTracker.Clear();
            Order found = _context.Orders.AsNoTracking().FirstOrDefault(ordes => ordes.IDs == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Order with that PIN");
                        return null;}
                    return new Model.Order(found.IDs, found.Storefrontsss, found.Total, found.customernumber);
                }

        
                public Product GetProductss(int pin)            //ADD PRODUCT ID UPON UNCOMMENTING
                {
            _context.ChangeTracker.Clear();
            Product found = _context.Products.AsNoTracking().FirstOrDefault(produc => produc.ProductCode == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Product with that PIN");
                        return null;}
                    return new Model.Product(found.ProductName, found.ProductPrice, found.ProductCode);
                }

                public Storefront GetStorefrontss(int pin)              //ADD STORE ID UPON UNCOMMENTING                     
                {
            _context.ChangeTracker.Clear();
            Storefront found = _context.Storefronts.AsNoTracking().FirstOrDefault(storefr => storefr.storeID == pin);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Storefront with that PIN");
                        return null;}
                    return new Model.Storefront(found.Town, found.storeID);
                }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

            public List<Model.Customer> GetAllCustomers()
            {
            _context.ChangeTracker.Clear();
            return _context.Customers.AsNoTracking().Select(
                customer => new Customer(customer.name, customer.ID, customer.hometown)
                ).ToList();
            }

        public List<Product> GetAllProducts()
        {
            _context.ChangeTracker.Clear();
            return _context.Products.AsNoTracking().Select(
                produ =>produ
                ).ToList();
        }
        public List<Storefront> GetAllStorefronts()
        {
            _context.ChangeTracker.Clear();
            return _context.Storefronts.AsNoTracking().Select(
                storef => storef
                ).ToList();
        }
        public List<Inventory> GetAllInventories()
        {
            _context.ChangeTracker.Clear();
            return _context.Inventories.AsNoTracking().Select(
                inven => new Inventory(inven.InventoryId, inven.InventoryName, inven.InventoryQuantity, inven.StoreId)
                ).ToList();
        }

        public List<Manager> GetAllManagers()
        {
            _context.ChangeTracker.Clear();
            return _context.Managers.AsNoTracking().Select(
                manag => manag
                ).ToList();
        }

        public List<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }



        public Model.Order AddOrder(Model.Order order)
        {                   //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
            _context.ChangeTracker.Clear();
            _context.Orders.Add(
            new Order
            {
                IDs = order.IDs,
                Storefrontsss = order.Storefrontsss,
                Total = order.Total,
                customernumber = order.customernumber,
                
                
            }
            );
            _context.SaveChanges();
        
            return order;
        }




        
        public Model.Order GetOrder(int id, int cust)
        {                                   //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
            _context.ChangeTracker.Clear();
            Order found = _context.Orders.AsNoTracking().FirstOrDefault(ordes => ordes.IDs == id && ordes.IDs == cust);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Order with that PIN");
                        return null;}
                    return new Model.Order(found.IDs, found.Storefrontsss, found.Total, found.customernumber);
        }

        
        public Model.Inventory GetInventory(int id, int cust)

       {
            _context.ChangeTracker.Clear();
            //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
            Inventory found = _context.Inventories.AsNoTracking().FirstOrDefault(inven => inven.InventoryName == id && inven.StoreId == cust);  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Inventory with that combination");
                        return null;}
                    return new Model.Inventory(found.InventoryId, found.InventoryQuantity, found.InventoryName, found.StoreId);
        }


        public Inventory Inventory(Inventory inventory2BeUpdated)
        {
            
            _context.Inventories.Update(inventory2BeUpdated);
            _context.SaveChanges();
            return inventory2BeUpdated;
            /*Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);
        
            _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BeUpdated);
           

            Inventory oldInventorys = _context.Inventories.Find(inventory2BeUpdated.InventoryId);
           
        
            oldInventorys.InventoryQuantity = inventory2BeUpdated.InventoryQuantity;
            
             _context.Entry(oldInventory).CurrentValues.SetValues((inventory2BeUpdated));
            

            _context.SaveChanges();
           */


            //_context.ChangeTracker.Clear();
        }  



    
        public Order UpdateOrder(Order order2BeUpdated)
        {
            
            _context.Orders.Update(order2BeUpdated);
            _context.SaveChanges();
            return order2BeUpdated;

           /* Order oldOrder = _context.Orders.Find(order2BeUpdated.IDs);
        
            _context.Entry(oldOrder).CurrentValues.SetValues(order2BeUpdated);
           

            Order oldOrderss = _context.Orders.Find(order2BeUpdated.IDs);
           
        
            oldOrderss.Total = order2BeUpdated.Total;
            
             _context.Entry(oldOrder).CurrentValues.SetValues((order2BeUpdated));
            

            _context.SaveChanges();*/
           

          
            //_context.ChangeTracker.Clear();
        }  


        public bool GetOrderT(int pin)
        {
            _context.ChangeTracker.Clear();
            Order found = _context.Orders.FirstOrDefault(ordes => ordes.IDs == pin );  
                    if (found == null) 
                    { Console.WriteLine("Did Not find Order with that PIN");
                        return false;}
                    return true;
        }

        public List<Inventory> GetInventoryById(int nums)
        {
            _context.ChangeTracker.Clear();

            return _context.Inventories.Where(
                inven => inven.StoreId == nums
                ).Select(
                    inven => inven
                ).ToList();
        }

        public List<Order> GetOrderById(int nums)
        {
            _context.ChangeTracker.Clear();
            return _context.Orders.AsNoTracking().Where(
                orde => orde.customernumber  == nums
                ).Select(
                    orde => orde
                ).ToList();
        }

        public List<LineItem> GetLineItemById(int nums)
        {
            _context.ChangeTracker.Clear();
            return _context.LineItems.AsNoTracking().Where(
                orde => orde.orderID == nums
                ).Select(
                    orde => orde
                ).ToList();
        }

        public Model.LineItem GetLineItem(Model.LineItem lineItem) // Customer Creation
        {
            _context.ChangeTracker.Clear();
            LineItem found = _context.LineItems.AsNoTracking().FirstOrDefault(custo => custo.orderID == lineItem.orderID && custo.itemID == lineItem.itemID) ;
            if (found == null) return null;
            return new Model.LineItem(found.itemID, found.Quantity, found.orderID, found.productID);
        }


        public void  UpdateInventories(int store, int prods)
        {
           
            Inventory inventory2BeUpdated = GetInventory(prods, store);
            inventory2BeUpdated.InventoryQuantity = inventory2BeUpdated.InventoryQuantity - 1;

            _context.Inventories.Update(inventory2BeUpdated);
            _context.SaveChanges();
            
            /*Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);
        
            _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BeUpdated);
           

            Inventory oldInventorys = _context.Inventories.Find(inventory2BeUpdated.InventoryId);
           
        
            oldInventorys.InventoryQuantity = inventory2BeUpdated.InventoryQuantity;
            
             _context.Entry(oldInventory).CurrentValues.SetValues((inventory2BeUpdated));
            

            _context.SaveChanges();
           */


            //_context.ChangeTracker.Clear();
        }




        public void  UpdateOrders(int orde, int prods)
        {
            
            Order order2BeUpdated = GetOrderss(orde);
            order2BeUpdated.Total = order2BeUpdated.Total + prods;

            _context.Orders.Update(order2BeUpdated);
            _context.SaveChanges();
         

            /* Order oldOrder = _context.Orders.Find(order2BeUpdated.IDs);

             _context.Entry(oldOrder).CurrentValues.SetValues(order2BeUpdated);


             Order oldOrderss = _context.Orders.Find(order2BeUpdated.IDs);


             oldOrderss.Total = order2BeUpdated.Total;

              _context.Entry(oldOrder).CurrentValues.SetValues((order2BeUpdated));


             _context.SaveChanges();*/



            //_context.ChangeTracker.Clear();
        }
































        /*

































                public Model.Order GetLineItem(int id, int cust)
                {                                   //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
                          Entity.LineItem found = _context.LineItems.FirstOrDefault(linei => linei.OrderId == id && linei.OrderCustomerId == cust);  
                            if (found == null) 
                            { Console.WriteLine("Did Not find LineItem with that combination");
                                return null;}
                            return new Model.LineOrder(found., found., found., found.);
                }

                public Model.Inventory AddInventory(Inventory inventory)
                {                   //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
                    Console.WriteLine("YO ADRIAN WE MADE IT");
                    _context.Inventories.Add(
                    new Entity.Inventiory
                    {
                        OrderId = order.ID,
                        OrderTotal = order.Total,
                        OrderCustomerId = order.customernumber,
                        OrderStroreFrontId = order.Storefrontsss


                    }
                    );
                    _context.SaveChanges();
                    Console.WriteLine("YO ADRIAN WE MADE IT");
                    return inventory;
                }

                public Model.LineItem AddLineItem(LineItem lineItem)
                {                   //ID, STOREFRONT ID, TOTAL, CUSTOMERNUMBER
                    Console.WriteLine("YO ADRIAN WE MADE IT");
                    _context.LineItems.Add(
                    new Entity.LineItem
                    {
                        OrderId = order.ID,
                        OrderTotal = order.Total,
                        OrderCustomerId = order.customernumber,
                        OrderStroreFrontId = order.Storefrontsss


                    }
                    );
                    _context.SaveChanges();
                    Console.WriteLine("YO ADRIAN WE MADE IT");
                    return lineItem;
                }

                public bool GetStorefrontT(int pin, int )         // Login Interface
                        {                                           //ADD STORE ID UPON UNCOMMENTING

                         Entity.Inventory found = _context.Inventories.FirstOrDefault(inven => inven.OrderId == id && inven.OrderCustomerId == cust);  
                            if (found == null) 
                            { Console.WriteLine("Did Not find Inventory with that combination");
                                return false;}
                            return true



                        }
                public bool GetStorefrontT(int pin, int)         // Login Interface
                        {                                           //ADD STORE ID UPON UNCOMMENTING
                          Entity.LineItem found = _context.LineItems.FirstOrDefault(linei => linei.OrderId == id && linei.OrderCustomerId == cust);  
                            if (found == null) 
                            { Console.WriteLine("Did Not find LineItem with that combination");
                                return false;}
                            return true;
                            }

        */





























































































        /*
           public Model.Customer GetInventory(Model.Inventory inventory)
           {
               Entity.Inventory found = _context.Inventories.FirstOrDefault(inven => inven.StoreId == inventory.StoreId && inven.InventoryName == inventory.InventoryName);  
               if (found == null) return null;                    
               return new Model.Inventory(found.InventoryId, found.InventoryQuantity, found.InventoryName, found.StoreId);
           }
           public Model.LineItem GetLineItem(Model.LineItem lineItem)
           {
               Entity.LineItem found = _context.LineItems.FirstOrDefault(lineo => lineo.productID == lineItem.productID && lineo.orderID == lineItem.orderID);  
               if (found == null) return null;
               return new Model.LineItem(found.LineitemId, found.LineitemQuantity, found.LineorderId, found.LineproductId);
           }
           public Model.Order GetOrder(Model.Order order)
           {
               Entity.Order found = _context.Orders.FirstOrDefault(orde => orde.OrderCustomerId == order.customernumber && orde.OrderId == order.ID);  
               if (found == null) return null;
                               return new Model.Order(found.Dates, found.OrderId, found.OrderTotal, found.OrderCustomerId, found.OrderStroreFrontId);
               }
                


               public Model.Product GetProduct(Model.Product product)
               {
                   Entity.Product found = _context.Products.FirstOrDefault(produ => produ.ProductCode == product.ProductCode);  
                   if (found == null) return null;
                   return new Model.Product(found.ProductName, found.ProductPrice, found.ProductCode);
               }

               public Model.Storefront GetStorefront(Model.Storefront storefront)
               {
                   Entity.Storefront found = _context.Storefronts.FirstOrDefault(storef => storef.StorefrontId == storefront.storeID);  
                   if (found == null) return null;
                   return new Model.Storefront(found.StorefrontTown, found.StorefrontId);
               }




       public List<Product> GetAllProducts()
       {
           throw new System.NotImplementedException();
       }

       public List<Storefront> GetStorefronts()
       {
           throw new System.NotImplementedException();
       }

       public List<Order> GetOrders()
       {
           throw new System.NotImplementedException();
       }



       /*        public Model.Storefront AddStorefront (Model.Storefront storefront)
               {
                       _context.Storefronts.Add(
                           new Entity.Storefront
                           {
                               StorefrontId = storefront.ID,
                               StorefrontTown= storefront.town,
                           }
                       );
                       _context.SaveChanges();
                       return storefront;
               }   
                public Model.Customer AddStorefront(Model.Storefront Storefront)
               {

                   _context.Storefront.Add(
                   new Entity.Storefront
                   {
                       town = Storefront.town
                   }
                   );
                   _context.SaveChanges();
                   return Storefront;
               }

               public Model.Order AddOrder(Model.Order order)
               {

                   _context.Order.Add(
                   new Entity.Order
                   {
                       id = GetCustomer(customer).ID,
                       Storefront = order.Storefront,
                       total =  order.total,
                       ordernumber = order.ordernumber
                   }
                   );
                   _context.SaveChanges();
                   return order;
               }

               public Model.Product AddProduct(Model.Product product)
               {

                   _context.Product.Add(
                   new Entity.Product
                   {
                       name = product.name,
                       price = product.price
                   }
                   );
                   _context.SaveChanges();
                   return product;
               }

               public List<Model.Customer> GetAllCustomers()
               {
                   return _context.Customers
                   .Select(
                       customer => new Model.Customer(customer.name, customer.id, customer.hometown)
                   ).ToList();
               }

               public List<Model.Customer> GetAllOrders()
               {
                   return _context.Orders
                   .Select(
                       order => new Model.Order(order.id, order.Storefront, order.total, order.ordernumber)
                   ).ToList();
               }

               public List<Model.Customer> GetAllStorefronts()
               {
                   return _context.Storefronts
                   .Select(
                       Storefront => new Model.Storefront(Storefront.name)
                   ).ToList();
               }

               public List<Model.Product> GetAllProducts()
               {
                   return _context.Products
                   .Select(
                       product => new Model.Product(product.name, product.price)
                   ).ToList();
               }



               public Model.Store GetOrder(Model.Order order)
               {
                   return _context.Orders.Where(
                       order => order.id == GetCustomer(customer).Id
                       ).Select(
                           order => new Model.Order
                           {
                               Id = order.id,
                               Storefront = order.Storefront,
                               Total = order.total,
                               Ordernumber = order.ordernumber

                           }
                       ).ToList();
               }

               public Model.Store GetProduct(Model.Product product)
               {
                   Entity.Product found = _context.Product.FirstOrDefault(produ => produ.Name == product.name && produ.price == product.price);  
                   if (found == null) return null;
                   return new Model.Product(found.name, found.price);
               }

               public Model.Store GetStorefront(Model.Storefront Storefront)
               {
                   Entity.Storefront found = _context.Storefront.FirstOrDefault(locat => locat.Name == Storefront.name);  
                   if (found == null) return null;
                   return new Model.Storefront(found.name);
               }
               */

    }
}

