public class Order
{
    public Order(List<WarehouseItem> items)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        if (items.Count == 0)
            throw new ArgumentOutOfRangeException(nameof(items));

        Paylink = $"{items.GetHashCode()}";
    }

    public string Paylink { get; }
}