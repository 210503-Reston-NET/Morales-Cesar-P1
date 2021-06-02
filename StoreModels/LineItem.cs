using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and Storefronts.  
    /// </summary>
    public class LineItem
    {
        private int _Quantity;


        public LineItem(int itemID, int Quantity, int orderID, int productID)
        {
            this.itemID = itemID;
            this.Quantity = Quantity;
            this.orderID = orderID;
            this.productID = productID;
        }

        public LineItem()
        { }


        [Key]
        public int itemID { get; set; }
    

        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (_Quantity < -1)
                {
                    throw new Exception("Quantity must be greater than -1");
                }
                _Quantity = value;
            }
        }
        public int orderID { get; set; }
        public int productID { get; set; }
        
    }
}