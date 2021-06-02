using System.Collections.Generic;
using StoreModels;
namespace DatLog
{
    public interface IRepository
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Manager AddManager(Manager manager);
        Customer GetCustomer(Customer customer);
        Manager GetManager(Manager manager);

        Customer GetCustomers(Customer customer);
        Customer GetCustomerss(int pin);

        Product AddProduct(Product product);

        Storefront AddStorefront(Storefront storefront);
        Inventory AddInventory(Inventory inventory);

        bool GetCustomerT(int pin);

        bool GetManagerT(int pin);
        
        bool GetProductT(int pin);

        bool GetStorefrontT(int pin);
        
        Manager GetManagerss(int pin);
        Order GetOrderss(int pin);
        Product GetProductss(int pin);
        Storefront GetStorefrontss(int pin);




        Order AddOrder(Order order);
        Order GetOrder(int id, int cust);
        Inventory GetInventory(int id , int cust);
        Inventory Inventory(Inventory inventory2BeUpdated);
        Order UpdateOrder(Order order2BeUpdated);

        bool GetOrderT(int pin);
        List<Inventory> GetAllInventories();
        List<Storefront> GetAllStorefronts();
        List<Manager> GetAllManagers();

        void UpdateInventories(int store, int prod);
        void UpdateOrders(int orde, int prods);








        /*  Inventory AddInventory(inventory); 

            Inventory GetInventoryT(id , cust);

            Inventory AddLineItem(lineitem); 
            Inventory GetLineItem(id , cust);
            Inventory GetLineItemT(id , cust);




        */


        //List<Storefront> GetStorefronts();
        //Customer GetStorefront(Storefront storefront);


        List<Product> GetAllProducts();
        List<Order> GetOrders();

        List<Inventory> GetInventoryById(int nums);

        List<Order> GetOrderById(int nums);
        List<LineItem> GetLineItemById(int nums);
        LineItem AddLineItem(LineItem lineItem);
        LineItem GetLineItem(LineItem lineitem);





    }
}