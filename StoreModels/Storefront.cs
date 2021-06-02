using System.ComponentModel.DataAnnotations;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store Storefront.
    /// </summary>
    public class Storefront
    {
        public Storefront(string Town, int storeID)
        {
            this.Town = Town;
            this.storeID = storeID;
        }

        public Storefront()
        { }

        public string Town { get; set; }

        [Key]
        public int storeID { get; set; }




        public override string ToString()
        {
            return $" Town: {Town} \n Store ID: {storeID}";
        }
        
    }
}