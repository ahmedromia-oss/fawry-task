using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

public class Order
{
    public void Checkout(Customer customer)
    {
        if (customer.cart.IsEmpty)
            throw new Exception("Cart is empty");

        double subtotal = 0;
        var shippableItems = new List<IShippable>();
     
        foreach (var item in customer.cart.Items)
        {
          
            if (item.Product is IExpirable expirable && expirable.IsExpired)
                throw new Exception($"{item.Product.Name} is expired");



            if (item.Product is IShippable shippable)
                shippableItems.Add(shippable);

            subtotal += item.TotalPrice;
        }
        var shippingService = new ShippingService();

        var shippingFees = shippingService.Ship(shippableItems);
        double total = subtotal + shippingFees;

        if (customer.Balance < total)
            throw new Exception("Insufficient balance");

        customer.Balance -= total;

        Console.WriteLine("Checkout successful:");
        Console.WriteLine($"Subtotal: ${subtotal}");
        Console.WriteLine($"Shipping: ${shippingFees}");
        Console.WriteLine($"Total Paid: ${total}");
        Console.WriteLine($"Remaining Balance: ${customer.Balance}");

        // Ship items


        // Update product stock
        foreach (var item in customer.cart.Items)
        {
            item.Product.Quantity -= item.Quantity;
        }

        // Empty cart after checkout
        customer.cart = new Cart();
    }
}
