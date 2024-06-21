public class Order
{
    private readonly List<WarehouseItem> _items;

    public Order(List<WarehouseItem> items)
    {
        if (items == null)
            throw new ArgumentNullException("items");

        if (items.Count == 0)
            throw new ArgumentOutOfRangeException("items");

        _items = items;
        Paylink = $"{items.GetHashCode()}";
    }

    public IReadOnlyList<WarehouseItem> Items => _items;

    public string Paylink { get; }
}