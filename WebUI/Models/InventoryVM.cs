
using StoreModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class InventoryVM
    {

        public InventoryVM(Inventory inventory)
        {
            inventoryid = inventory.InventoryId;
            inventoryQuantity = inventory.InventoryQuantity;
            inventoryName = inventory.InventoryName;
            storeId = inventory.StoreId;
        }

        public InventoryVM()
        { }

        public int inventoryid { get; set; }

        [Required]
        [Range (0,100000000000000)]
        public int inventoryQuantity { get; set; }
        public int inventoryName { get; set; }
        public int storeId { get; set; }
    }
}
