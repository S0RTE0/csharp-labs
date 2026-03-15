public class Lab4
{
    public static void Main(string[] args)
    {
        Dictionary<string, double> catalog = new Dictionary<string, double>()
        {
            {"Cola", 30.00},
            {"Coffee", 26.00},
            {"Burger", 67.00},
            {"HotDog", 72.00}
        };

        List<string> cart = new List<string>();
        int choice;

        do
        {
            Console.Write("""
                          [0] Exit
                          [1] See catalog
                          [2] Add goods
                          [3] Remove goods
                          [4] Place an order

                          """);

            choice = GetInt("Select an option: ");

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    ShowCatalog(catalog);
                    break;
                case 2:
                    Console.WriteLine("What would you like to add?");
                    string itemToAdd = Console.ReadLine();
                    AddToCart(itemToAdd, catalog, cart);
                    break;
                case 3:
                    Console.WriteLine("What would you like to remove?");
                    string itemToRemove = Console.ReadLine();
                    RemoveFromCart(itemToRemove, cart);
                    break;
                case 4:
                    PlaceOrder(catalog, cart);
                    choice = 0; 
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        } while (choice != 0);

        Console.WriteLine("Exiting...");
    }

    private static void ShowCatalog(Dictionary<string, double> catalog)
    {
        Console.WriteLine("\n--- Catalog ---");
        foreach (var product in catalog)
        {
            Console.WriteLine($"{product.Key}: {product.Value}");
        }
        Console.WriteLine("---------------\n");
    }

    private static void AddToCart(string item, Dictionary<string, double> catalog, List<string> cart)
    {
        if (catalog.ContainsKey(item))
        {
            cart.Add(item);
            Console.WriteLine($"Added {item} to the cart.\n");
        }
        else
        {
            Console.WriteLine("Error: Such item does not exist in the catalog.\n");
        }
    }

    private static void RemoveFromCart(string item, List<string> cart)
    {
        if (cart.Contains(item))
        {
            cart.Remove(item);
            Console.WriteLine($"Removed {item} from the cart.\n");
        }
        else
        {
            Console.WriteLine("Item not found in your cart.\n");
        }
    }

    private static double CalculateTotal(Dictionary<string, double> catalog, List<string> cart)
    {
        double total = 0;
        foreach (var item in cart)
        {
            total += catalog[item];
        }
        return total;
    }

    private static void PlaceOrder(Dictionary<string, double> catalog, List<string> cart)
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty. Nothing to order.\n");
            return;
        }

        Console.WriteLine("\n--- Your Receipt ---");
        Dictionary<string, int> receipt = new Dictionary<string, int>();

        foreach (var cartItem in cart)
        {
            if (receipt.ContainsKey(cartItem))
                receipt[cartItem]++;
            else
                receipt[cartItem] = 1;
        }

        foreach (var entry in receipt)
        {
            double itemPrice = catalog[entry.Key];
            double totalItemCost = itemPrice * entry.Value;
            Console.WriteLine($"{entry.Key} x{entry.Value} - {totalItemCost}");
        }

        double total = CalculateTotal(catalog, cart);
        Console.WriteLine("--------------------");
        Console.WriteLine($"Total to pay: {total}");
        Console.WriteLine("Order placed successfully!\n");
    }

    private static int GetInt(string text)
    {
        int result;
        do
        {
            Console.Write(text);
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}