using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM(LineItem lineItem)
        {
            itemID = lineItem.itemID;
            Quantity = lineItem.Quantity;
            orderID = lineItem.orderID;
            productID = lineItem.productID;
        }
        public LineItemVM()
        {
        }
        public int itemID { get; set; }
        public int Quantity { get; set; }
        public int orderID { get; set; }
        public int productID { get; set; }



    
    }

}
