using System;

namespace PointOfSale
{
    class Program
    {
        private static AppleStore store = new AppleStore();
        private static Cart cart;

        static void Main(string[] args)
        {
            
            store.Add("A", new Product("iPod", "Portable Audio Player", "Black 256 GB", 199m));
            store.Add("B", new Product("iPhone", "Smartphone", "White 64 GB unlocked 4.7\" iPhone SE", 399m));
            store.Add("C", new Product("iPad", "Tablet", "Silver 32 GB Wi-Fi 10.0\"", 329m));
            store.Add("D", new Product("iMac", "Computer", "21.5” 2.3 Ghz i5, 8GB, 256GB SSD ", 1099m));
            store.Add("E", new Product("Macbook", "Portable Computer", "13” 1.1 Ghz i3, 8GB, 256GB SSD ", 999m));
            store.Add("F", new Product("Mac mini", "Computer", "3.6Ghz i3, 8GB, 256GB SSD ", 799m));
            store.Add("G", new Product("Pro Display", "Computer Display", "32”, 6k ", 4999m));
            store.Add("H", new Product("Mac Pro", "Computer", "3.5 Ghz Xeon W, 32GB, 256GB SSD ", 5999m));
            store.Add("I", new Product("iWatch", "Timepiece", "Silver with white sport band ", 399m));
            store.Add("J", new Product("AppleTV", "Media Player", "32GB, HD ", 149m));
            store.Add("K", new Product("AirPods", "Headphones", "White with Charging Case ", 159m));
            store.Add("L", new Product("HomePod", "Home Assistant", "Space Grey", 299m));

            while (true)
            {
                //set cart for new order
                cart = new Cart();
                bool shopping = true;
                //add items to cart and display menu repeating until checkout
                do
                {
                    Console.Clear();
                    DisplayMenu();
                    ProcessInput(Console.ReadLine(), ref shopping);
                } while (shopping);

                Checkout();
            }
        }

        private static void Checkout()
        {
            //checkout
            if (cart.Count != 0)
            {
                //ask for money, display subtotal, sales tax, and grand total first
                Console.WriteLine("\nPayment must be in cash.");
                Console.WriteLine($"Sub Total: {cart.SubTotal():c} \nSales Tax: {cart.SalesTax():c} \nGrand Total: {cart.GrandTotal():c}");

                decimal collected = 0;
                while (collected < cart.GrandTotal())
                {
                    Console.Write("Cash Remitted: ");
                    string input = Console.ReadLine();
                    if (decimal.TryParse(input, out decimal cash))
                    {
                        collected += cash;
                    }
                    Console.WriteLine($"Collected: {collected:C}, Amount Due: {cart.GrandTotal() - collected:C} ");
                }
                Console.WriteLine();
                string[] receipt = cart.GetReceipt();
                foreach (string line in receipt)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine($"Amount Tendered: {collected:c}");
                Console.WriteLine($"Change: {collected - cart.GrandTotal():c}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to the store.\n");
            Console.ReadKey(true);
        }

        private static void ProcessInput(string input, ref bool shopping)
        {
            if(store.IsValidItem(input))
            {
                Product item = store.GetProduct(input);
                //ask for quantity and add to cart
                int amount;
                while(!int.TryParse(input, out amount) || amount < 0)
                {

                    Console.Write($"How many {item.Name}{(item.Name[^1] == 's' ? "'" : "s")} would you like? ");
                    input = Console.ReadLine();
                }
                if (amount != 0)
                {
                    cart.Add(item, amount);

                    Console.WriteLine($"{amount} {item.Name}{(amount == 1 ? "" : (item.Name[^1] == 's' ? "'" : "s"))} added {item.Price:c} each, total of {cart.LineTotal(amount, item.Price):C}");
                    Console.WriteLine("\nPress any key to return to the menu.");

                    Console.ReadKey(true);
                }
            }
            else if(input.ToLower() == "checkout")
            {
                shopping = false;
            }
            else
            {
                Console.WriteLine("Invalid Entry, press any key to continue.");
                Console.ReadKey(true);
            }
        }

        private static void DisplayMenu()
        {
            string[] items = store.GetMenu();
            foreach(string item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nEnter a letter to add the item to your cart, or \"Checkout\" to complete purchase.");
            Console.Write("> ");
        }
    }
}
