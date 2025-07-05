using System.Net.Quic;

public class Cart
{
    public List<CartItem> Items { get; } = new();

    public void Add(Product product, int quantity)
    {
        if (quantity > product.Quantity)
            throw new Exception($"Not enough stock for {product.Name}");
        var item = Items.FindIndex((e) => e.Product.Id == product.Id);

        if (item == -1)
        {
            if (quantity > product.Quantity)
            {
                throw new Exception($"Not enough stock for {product.Name}");
            }
            Items.Add(new CartItem(product, quantity));

        }
        else
        {
            if (Items[item].Quantity + quantity <= product.Quantity)
            {

                Items[item].Quantity += quantity;
            }
            else
            {
                throw new Exception($"Not enough stock for {product.Name}");
            }


        }
    }

    public bool IsEmpty => !Items.Any();
    public double Subtotal => Items.Sum(item => item.TotalPrice);
}
