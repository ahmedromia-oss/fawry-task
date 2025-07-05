using System.Data.Common;

public abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int Id { get; set; }

    protected Product(string name, double price, int quantity , int id)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
