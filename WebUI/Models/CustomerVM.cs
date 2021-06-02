using StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM(Customer customer)
        {
            name = customer.name;
            id = customer.ID;
            hometown = customer.hometown;
        }
        public CustomerVM()
        { }

        public int id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string name { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        [Required]
        public string hometown { get; set; }


    }
}
