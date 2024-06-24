public class Warehouse : IWarehouseInteractor
{
    private readonly List<WarehouseItem> _items;

    public Warehouse()
    {
        _items = new List<WarehouseItem>();
    }

    public void Delive(Good good, int count)
    {
        Validate(good, count);

        WarehouseItem? existingItem = _items.FirstOrDefault(item => item.Good.Title == good.Title);

        if (existingItem == null)
        {
            _items.Add(new WarehouseItem(good, count));
        }
        else
        {
            existingItem.IncreaseCount(count);
        }
    }

    public IWarehouseItemReadonly GetItemFromWarehouse(Good good, int count)
    {
        return GetItem(good, count);
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        foreach (IWarehouseItemReadonly item in order.Items)
        {
            RemoveItem(item);
        }
    }

    public void ViewItems()
    {
        Console.WriteLine($"Warehouse");

        foreach (var item in _items)
        {
            Console.WriteLine($"Good:{item.Good.Title}, count:{item.Count}");
        }
    }

    private IWarehouseItemReadonly GetItem(Good good, int count)
    {
        Validate(good, count);

        WarehouseItem? existingItem = _items.FirstOrDefault(item => item.Good.Title == good.Title);

        if (existingItem == null)
        {
            throw new InvalidOperationException($"'{good.Title}' не найден на складе для добавления в корзину");
        }

        if (existingItem.Count < count)
        {
            throw new InvalidOperationException($"На складе недостаточное кол-во '{good.Title}' для добавления в корзину");
        }

        return new WarehouseItem(existingItem.Good, count);
    }

    private void RemoveItem(IWarehouseItemReadonly item)
    {
        Validate(item);

        WarehouseItem? existingItem = _items.FirstOrDefault(item => item.Good.Title == item.Good.Title);

        if (existingItem == null)
        {
            throw new InvalidOperationException($"'{item.Good.Title}' не найден на складе для оформления заказа");
        }

        if (existingItem.Count < item.Count)
        {
            throw new InvalidOperationException($"На складе недостаточное кол-во '{item.Good.Title}' для оформления заказа");
        }

        existingItem.DecreaseCount(item.Count);
    }

    private void Validate(IWarehouseItemReadonly item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        Validate(item.Good, item.Count);
    }

    private void Validate(Good good, int count)
    {
        if (good == null)
            throw new ArgumentNullException(nameof(good));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));
    }
}