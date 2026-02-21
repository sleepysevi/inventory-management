using InventoryManagement.Services;

namespace InventoryManagement.Views
{
    public class InventoryView
    {
        private InventoryService inventoryService;

        public InventoryView()
        {
            inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("    Inventory Management     ");
                Console.WriteLine("=============================");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                    ShowInventory();
                else if (choice == "2")
                    UpdateStock();
                else if (choice == "3")
                    ResetInventory();
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting... Goodbye!");
                    running = false;
                }
                else
                    Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        public void ShowInventory()
        {
            string[,] inventory = inventoryService.GetInventory();

            Console.WriteLine("\n--- Current Inventory ---");
            Console.WriteLine("No.  Product        Stock");
            Console.WriteLine("-------------------------");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + ".   " + inventory[0, i] + "         " + inventory[1, i]);
            }
        }

        public void UpdateStock()
        {
            ShowInventory();

            Console.Write("\nEnter product number (1-3): ");
            string input = Console.ReadLine();
            int productNum = int.Parse(input);

            if (productNum < 1 || productNum > 3)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            Console.Write("Enter new stock: ");
            string newStock = Console.ReadLine();

            bool result = inventoryService.UpdateStock(productNum - 1, newStock);

            if (result == true)
                Console.WriteLine("Stock updated!");
            else
                Console.WriteLine("Something went wrong.");
        }

        public void ResetInventory()
        {
            inventoryService.ResetInventory();
            Console.WriteLine("Inventory has been reset!");
            ShowInventory();
        }
    }
}