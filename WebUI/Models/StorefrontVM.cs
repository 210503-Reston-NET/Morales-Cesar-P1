using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace WebUI.Models
{
    public class StorefrontVM
    {

        public StorefrontVM (Storefront storefront)
        {
            this.ID = storefront.storeID;
            this.Name = storefront.Town;

        }
        public StorefrontVM()
        { }


        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
