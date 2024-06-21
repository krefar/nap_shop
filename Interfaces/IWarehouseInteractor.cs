public interface IWarehouseInteractor
{
    IWarehouseItemReadonly GetItemFromWarehouse(Good good, int count);

    void ProcessOrder(Order order);
}