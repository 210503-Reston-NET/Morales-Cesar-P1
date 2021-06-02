using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class OrderVM
    {
        public OrderVM(Order order)
        {
            IDs = order.IDs;
            Storefrontsss = order.Storefrontsss;
            Total = order.Total;
            customernumber = order.customernumber;
        }
        public OrderVM()
        { }


        public int IDs { get; set; }
        public int Storefrontsss { get; set; }
        public int Total { get; set; }
        public int customernumber { get; set; }


    }
}
