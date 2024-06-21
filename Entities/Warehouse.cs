public class Warehouse
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

    public WarehouseItem GetItem(Good good, int count)
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
    
    public void RemoveItem(WarehouseItem item)
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

    private void Validate(WarehouseItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        Validate(item.Good, item.Count);
    }

    public void ViewItems()
    {
        Console.WriteLine($"Warehouse");

        foreach (var item in _items)
        {
            Console.WriteLine($"Good:{item.Good.Title}, count:{item.Count}");
        }
    }

    private void Validate(Good good, int count)
    {
        if (good == null)
            throw new ArgumentNullException(nameof(good));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));
    }
}