public class TV : Product, IShippable
{
    public double Weight { get; }

    public TV(int id , string name, double price, int quantity, double weight)
        : base(name, price, quantity , id)
    {
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
}