namespace StoreModels
{
    public class Inventory
    {
        private string _name;
        private string _hometown;
        private int _ID;

        public Inventory(int InventoryId, int InventoryQuantity, int InventoryName, int StoreId)
        {
            this.InventoryId = InventoryId;
            this.InventoryQuantity = InventoryQuantity;
            this.InventoryName = InventoryName;
            this.StoreId = StoreId;
        }

        public Inventory()
        {

        }
        //TODO: add more properties to identify the customer
        public int InventoryId { get; set; }
        public int InventoryQuantity { get; set; }
        public int InventoryName { get; set; }
        public int StoreId { get; set; }
       

        public override string ToString()
        {
            return $" Product: {InventoryName} \n StoreID: {StoreId} \n Quantity {InventoryQuantity}";
        }

    
    }
}