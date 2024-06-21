var iPhone12 = new Good("IPhone 12");
var iPhone11 = new Good("IPhone 11");

var warehouse = new Warehouse();

var shop = new Shop(warehouse);

warehouse.Delive(iPhone12, 10);
warehouse.Delive(iPhone11, 1);

//Вывод всех товаров на складе с их остатком
foreach (WarehouseItem item in warehouse.Items)
{
    Console.WriteLine($"Good:{item.Good.Title}, count:{item.Count}");
}

Cart cart = shop.Cart();
cart.Add(iPhone12, 4);
cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

//Вывод всех товаров в корзине
foreach (WarehouseItem item in cart.Items)
{
    Console.WriteLine($"Good:{item.Good.Title}, count:{item.Count}");
}

Console.WriteLine(cart.Order().Paylink);

cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары