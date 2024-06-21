public class Order
{
    private readonly List<IWarehouseItemReadonly> _items;

    public Order(List<IWarehouseItemReadonly> items)
    {
        if (items == null)
            throw new ArgumentNullException("items");

        if (items.Count == 0)
            throw new ArgumentOutOfRangeException("items");

        _items = items;
        Paylink = $"{items.GetHashCode()}";
    }

    public IReadOnlyList<IWarehouseItemReadonly> Items => _items;

    public string Paylink { get; }
}