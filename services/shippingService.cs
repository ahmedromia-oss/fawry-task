

public class ShippingService
{
    private static  double ShippingRatePerKg = 5.0;

    public double Ship(List<IShippable> items)
    {
        
        double shipFees = 0;
        foreach (var item in items)
        {
          
            shipFees += item.GetWeight() * ShippingRatePerKg;

        }
        return shipFees;

    }
}
