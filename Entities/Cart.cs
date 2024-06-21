public class Cart
{
    private readonly Shop _shop;
    private readonly List<WarehouseItem> _items;

    public Cart(Shop shop)
    {
        _shop = shop ?? throw new ArgumentNullException(nameof(shop));
        _items = new List<WarehouseItem>();
    }

    public IReadOnlyList<WarehouseItem> Items => _items;

    public void Add(Good good, int count)
    {
        _items.Add(_shop.GetItem(good, count));
    }

    public Order Order()
    {
        return new Order(_items);
    }
}