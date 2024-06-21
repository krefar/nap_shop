public class WarehouseWorker : IWarehouseInteractor
{
    private readonly Warehouse _warehouse;

    public WarehouseWorker(Warehouse warehouse)
    {
        _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
    }

    public IWarehouseItemReadonly GetItemFromWarehouse(Good good, int count)
    {
        return _warehouse.GetItem(good, count);
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        foreach (IWarehouseItemReadonly item in order.Items)
        {
            _warehouse.RemoveItem(item);
        }
    }
}