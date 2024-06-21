﻿public class WarehouseWorker
{
    private readonly Warehouse _warehouse;

    public WarehouseWorker(Warehouse warehouse)
    {
        _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
    }

    public WarehouseItem GetItemFromWarehouse(Good good, int count)
    {
        return _warehouse.GetItem(good, count);
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        foreach (WarehouseItem item in order.Items)
        {
            _warehouse.RemoveItem(item);
        }
    }
}