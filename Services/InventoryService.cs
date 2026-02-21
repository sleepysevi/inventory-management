namespace InventoryManagement.Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[,] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },
                { "10",     "5",    "20"    }
            };

            initialStock = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },
                { "10",     "5",    "20"    }
            };
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public int GetProductCount()
        {
            return products.GetLength(1);
        }

        public bool UpdateStock(int productIndex, string newQuantity)
        {
            if (productIndex < 0 || productIndex >= GetProductCount())
                return false;

            products[1, productIndex] = newQuantity;
            return true;
        }

        public void ResetInventory()
        {
            for (int i = 0; i < GetProductCount(); i++)
            {
                products[1, i] = initialStock[1, i];
            }
        }
    }
}