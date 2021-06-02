using StoreModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ManagerVM
    {

        public ManagerVM(Manager manager)
        {
            name = manager.name;
            Id = manager.ID;
            
        }
        public ManagerVM ()
        {

        }
        public int Id { get; set; }
        [Required]
        public string name { get; set; }



    }
}