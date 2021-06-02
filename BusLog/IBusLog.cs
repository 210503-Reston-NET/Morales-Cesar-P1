using System.Collections.Generic;
using System;
using StoreModels;

namespace BusLog
{
    public interface IBusLog
    {
        List<Customer> GetAllCustomers();
        List<Inventory> GetAllInventories();
        List<Storefront> GetAllStorefronts();
        List<Product> GetAllProducts();
        List<Manager> GetAllManagers();
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);
        Customer GetCustomer3(int pin);
        Product AddProduct(Product product);
        Inventory AddInventory(Inventory inventory);
        Storefront AddStorefront(Storefront storefront);
        Manager AddManager(Manager manager);
        Manager GetManager(Manager manager);
        bool GetCustomerT(int pin);
        bool GetManagerT(int pin);
        
        bool GetProductT(int pin);
        bool GetStorefrontT(int pin);

        bool GetOrderT(int pin);
        Product GetProduct3(int pin);
        Storefront GetStorefront3(int pin);
        

        Customer GetCustomer2(Customer customer);
        Manager GetManager3 (int pin);
        Order GetOrder3 (int pin);

        Order AddOrder(Order order);
        Order GetOrder(int id, int cust );


        Inventory GetInventory(int id, int cust );
        Inventory UpdateInventory(Inventory inventory2BeUpdated);
        Order UpdateOrder(Order order2BeUpdated);


        List<Inventory> GetInventoryById(int nums);

        List<Order> GetOrderByID(int nums);
        List<LineItem> GetLineItemsById(int nums);
        LineItem AddLineItem(LineItem lineItem);

        void UpdateInventories(int store, int prod);
        void UpdateOrders(int orde, int prods);



        /*
            public Inventory AddInventory(Order order);

            Inventory GetInventory(int id, int cust );

            Inventory GetInventory3(int id, int cust );

            LineItem AddLineItem(LineItem lineitem);

            LineItem GetLineItem(int id, int cust );

            LineItem GetLineItemy3(int id, int cust);










          */















        /*  List<Storefront> GetAllStorefronts();
          List<Product> GetAllProducts();
          List<Order> GetAllOrders();





          Storefront AddStorefront(Storefront Loctaion);
          Product AddProduct(Product Product);




          Storefront GetStorefront(Storefront Storefront);
          Product GetProduct(Product product);
          */

    }
}