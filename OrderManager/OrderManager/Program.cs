using OrderManager;

COrderManager orderManager = new COrderManager();
orderManager.InputData();
while ( !orderManager.CheckOrder() )
{
    Console.WriteLine( "Введите данные еще раз" );
    orderManager.InputData();
}
orderManager.SuccessfulOrdering();
