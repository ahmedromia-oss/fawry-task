using System.Data.Common;

public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public int Id { get; set; }
    public Cart cart { get; set; } = new Cart();


    public Customer(string name, double balance, int id)
    {
        Id = id;
        Name = name;
        Balance = balance;
    }
}
