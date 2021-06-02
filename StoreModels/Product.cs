using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
         private double _Price;

        public Product (string ProductName, int ProductPrice, int ProductCode)
        {
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.ProductCode = ProductCode;
           
            
        }   
        public Product()
        { }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        [Key]
        public int ProductCode { get; set; }
        //todo: add more properties to define a product (maybe a category?)
    
    
        public override string ToString()
        {
            return $"Product: {ProductName} \n Price: {ProductPrice} \n Barcode {ProductCode}";
        }
    
    
    }
}