public class Cheese : Product, IShippable, IExpirable
{
    public DateTime ExpiryDate { get; }

    public double Weight { get; }

    public Cheese(int id , string name, double price, int quantity, DateTime expiryDate, double weight)
        : base(name, price, quantity ,id)
    {
        ExpiryDate = expiryDate;
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;

    public bool IsExpired => DateTime.Now > ExpiryDate;
}