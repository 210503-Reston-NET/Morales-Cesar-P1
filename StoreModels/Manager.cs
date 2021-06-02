using System;
using System.Text.RegularExpressions;
namespace StoreModels
{
    public class Manager
    {
        private string _name;

        public Manager(string name, int ID)
        {
            this.name = name;
            this.ID = ID;
        }
        public Manager()
        { }

        //TODO: add more properties to identify the customer
        public string name
        {
            get{return _name;}
            set{
                if(!Regex.IsMatch(value, @"^[A-Za-z .]+")) throw new Exception("Customer's name cannot have numbers");
                _name = value;
             }
        }
        public int ID { get; set; }
    }
}