var iPhone12 = new Good("IPhone 12");
var iPhone11 = new Good("IPhone 11");

var warehouse = new Warehouse();
var warehouseWorker = new WarehouseWorker(warehouse);
var shop = new Shop();

warehouse.Delive(iPhone12, 10);
warehouse.Delive(iPhone11, 1);

//Вывод всех товаров на складе с их остатком
warehouse.ViewItems();

Cart cart = shop.Cart();
cart.Add(iPhone12, 4, warehouseWorker);
cart.Add(iPhone11, 3, warehouseWorker); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

//Вывод всех товаров в корзине
cart.ViewItems();

Console.WriteLine(cart.Order(warehouseWorker).Paylink);

cart.Add(iPhone12, 9, warehouseWorker); //Ошибка, после заказа со склада убираются заказанные товары