public class Warehouse
{
    private readonly List<WarehouseItem> _items;

    public Warehouse()
    {
        _items = new List<WarehouseItem>();
    }

    public IReadOnlyList<WarehouseItem> Items => _items;

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
            existingItem.Count += count;
        }
    }

    public WarehouseItem GetItem(Good good, int count)
    {
        Validate(good, count);

        WarehouseItem? existingItem = _items.FirstOrDefault(item => item.Good.Title == good.Title);

        if (existingItem == null)
        {
            throw new InvalidOperationException($"'{good.Title}' не найден на складе");
        }

        if (existingItem.Count < count)
        {
            throw new InvalidOperationException($"На складе недостаточное кол-во '{good.Title}'");
        }

        existingItem.Count -= count;

        return new WarehouseItem(existingItem.Good, count);
    }

    private void Validate(Good good, int count)
    {
        if (good == null)
            throw new ArgumentNullException(nameof(good));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));
    }
}