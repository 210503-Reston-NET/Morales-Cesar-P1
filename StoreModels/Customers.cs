using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        private string _name;
        private string _hometown;
        private int _ID;

        public Customer(string name, int ID, string hometown)
        {
            this.name = name;
            this.ID = ID;
            this.hometown = hometown;
        }
        public Customer()
        {}

        //TODO: add more properties to identify the customer
        public string name
        {
            get{return _name;}
            set{
                if(!Regex.IsMatch(value, @"^[A-Za-z .]+")) throw new Exception("Customer's name cannot have numbers");
                _name = value;
             }
        }
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID >  999 || _ID < 10000)
                {
                    //throw new Exception("This should be a 4 digit ID number... OOF");
                }
                _ID = value;
            }
        }


        public string hometown
        {
            get{return _hometown;}
            set{
                if(!Regex.IsMatch(value, @"^[A-Za-z .]+$")) throw new Exception("Customer's hometown cannot have numbers 1111");
                _hometown = value;
             }
        }

        //public List<Review> Reviews { get; set; }
        public override string ToString()
        {
            return $" Name: {name} \n HomeTown: {hometown} ID: {ID}";
        }
        //public bool Equals(Restaurant restaurant)
        //{
           // return this.Name.Equals(restaurant.Name) && this.City.Equals(restaurant.City) && this.State.Equals(restaurant.State);
        //}
    }
}