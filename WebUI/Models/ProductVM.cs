using StoreModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductVM
    {
        public ProductVM(Product product)
        {
            productname = product.ProductName;
            productprice = product.ProductPrice;
            productcode = product.ProductCode;

        }
        public ProductVM()
        { }

        [DisplayName("Product Name")]
        [Required]
        public string productname { get; set; }
        [Required]
        [DisplayName ("Price")]
        public int productprice { get; set; }
        
        public int productcode { get; set; }
    }
}
