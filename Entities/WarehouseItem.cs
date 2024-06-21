public class WarehouseItem : IWarehouseItemReadonly
{
    public WarehouseItem(Good good, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Good = good ?? throw new ArgumentNullException(nameof(good));
        Count = count;
    }

    public Good Good { get; }
    public int Count { get; private set; }

    public void IncreaseCount(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Count += count;
    }
    
    public void DecreaseCount(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Count -= count;
    }
}