public class Cart
{
    private readonly List<WarehouseItem> _items;

    public Cart()
    {
        _items = new List<WarehouseItem>();
    }

    public void Add(Good good, int count, WarehouseWorker worker)
    {
        if (worker == null)
            throw new ArgumentNullException(nameof(worker));

        _items.Add(worker.GetItemFromWarehouse(good, count));
    }

    public Order Order(WarehouseWorker worker)
    {
        if (worker == null)
            throw new ArgumentNullException(nameof(worker));

        var order = new Order(_items);

        worker.ProcessOrder(order);

        return order;
    }

    public void ViewItems()
    {
        Console.WriteLine($"Cart");

        foreach (var item in _items)
        {
            Console.WriteLine($"Good:{item.Good.Title}, count:{item.Count}");
        }
    }
}