
public class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new TV(1 , "Samsung TV", 5000, 5, 15),
            new Cheese(2 , "Cheddar", 40, 10, DateTime.Now.AddDays(3), 1),
            new MobileCard ( "Vodafone Card", 10, 30 , 3)
        };

        var customer = new Customer("Ahmed", 1000 , 1);
        var order = new Order();

        while (true)
        {
            Console.WriteLine("\n Available Products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }

            Console.WriteLine("0. Checkout and Exit");
            Console.Write("Select a product number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > products.Count)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            if (choice == 0)
            {
                try
                {
                    order.Checkout(customer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                break;
            }

            var selectedProduct = products[choice - 1];
            Console.Write($"Enter quantity for {selectedProduct.Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            try
            {
                customer.cart.Add(selectedProduct, qty);
                Console.WriteLine($"Added {qty} x {selectedProduct.Name} to cart.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
