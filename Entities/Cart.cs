public class Cart
{
    private readonly List<IWarehouseItemReadonly> _items;
    private readonly IWarehouseInteractor _interactor;

    public Cart(IWarehouseInteractor interactor)
    {
        if (interactor == null)
            throw new ArgumentNullException(nameof(interactor));

        _items = new List<IWarehouseItemReadonly>();
        _interactor = interactor;
    }

    public void Add(Good good, int count)
    {
        _items.Add(_interactor.GetItemFromWarehouse(good, count));
    }

    public Order Order()
    {
        var order = new Order(new List<IWarehouseItemReadonly>(_items));
        _interactor.ProcessOrder(order);
        
        _items.Clear();

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