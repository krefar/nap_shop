public class Shop
{
    private readonly Warehouse _warehouse;

    public Shop(Warehouse warehouse)
    {
        _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
    }

    public Cart Cart()
    {
        return new Cart(this);
    }

    public WarehouseItem GetItem(Good good, int count)
    {
        return _warehouse.GetItem(good, count);
    }
}