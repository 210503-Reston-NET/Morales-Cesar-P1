using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public  Order (int id, int Storefrontsss, int total, int customernumber)
        {
            
            this.IDs = id;
            this.Storefrontsss = Storefrontsss;
            this.Total =  total;
            this.customernumber = customernumber;

        }
        public Order()
        { }
        
        //private int _Id;
        private int _Total;
        private double _OrderNumber;

        [Key]
        public int IDs { get; set; }
            /*
            {get {return _Id;}
            set {
                    if (_Id <  999 || _Id > 10000)
                    {
                        throw new Exception("This should be a 4 digit ID number... OOF");
                    }
                    _Id = value;
            }*/
        
        public int Storefrontsss { get; set; }
        public int Total { get; set; }
        public int customernumber { get; set; }
        
        
        
        /* Testing{get {return (int)_OrderNumber;}
            set {
                    if(_Id <  99 || _Id > 1000)
                    {
                        throw new Exception("Invalid Order Number... OOF");
                    }
                    _OrderNumber = value;
            }*/
        }
    }

        //TODO: add a property for the order LineItems
