public class Cart
{
    private readonly List<IWarehouseItemReadonly> _items;

    public Cart()
    {
        _items = new List<IWarehouseItemReadonly>();
    }

    public void Add(Good good, int count, IWarehouseInteractor interactor)
    {
        if (interactor == null)
            throw new ArgumentNullException(nameof(interactor));

        _items.Add(interactor.GetItemFromWarehouse(good, count));
    }

    public Order Order(IWarehouseInteractor interactor)
    {
        if (interactor == null)
            throw new ArgumentNullException(nameof(interactor));

        var order = new Order(_items);

        interactor.ProcessOrder(order);

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