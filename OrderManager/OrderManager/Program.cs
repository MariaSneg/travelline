OrderManager orderManager = new OrderManager();
orderManager.InputData();
while ( !orderManager.CheckOrder() )
{
    Console.WriteLine( "Введите данные еще раз" );
    orderManager.InputData();
}
orderManager.SuccessfulOrdering();
