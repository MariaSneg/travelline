//using static System.Runtime.InteropServices.JavaScript.JSType;

OrderManager orderManager = new OrderManager();
orderManager.InputData();
while ( !orderManager.CheckOrder() )
{
    Console.WriteLine( "Введите данные еще раз" );
    orderManager.InputData();
}
orderManager.SuccessfulOrdering();

class OrderManager
{
    private Order _order = new Order();

    public void SuccessfulOrdering()
    {
        string productName = _order.GetProductName();
        int count = _order.GetCount();
        string name = _order.GetName();
        string address = _order.GetAddress();
        DateTime date = DateTime.Today.AddDays( 3 );

        Console.WriteLine( $"{name}! Ваш заказ {productName} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {date.ToShortDateString()}" );
    }
    public bool CheckOrder()
    {
        string productName = _order.GetProductName();
        int count = _order.GetCount();
        string name = _order.GetName();
        string address = _order.GetAddress();

        Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {productName} на адрес {address}, все верно? Ответ в виде Да/Нет" );
        string answer = Console.ReadLine();
        return ( answer == "Да" );
    }
    public void InputData()
    {
        Console.WriteLine( "Введите название товара: " );
        string productName = Console.ReadLine();
        _order.SetProductName( productName );

        Console.WriteLine( "Введите количество товара: " );
        string countStr = Console.ReadLine();
        if ( int.TryParse( countStr, out int count ) )
        {
            _order.SetCount( count );
        }
        else
        {
            Console.WriteLine( "Неверные данные. Введите число" );
        }

        Console.WriteLine( "Введите ваше имя: " );
        string name = Console.ReadLine();
        _order.SetName( name );

        Console.WriteLine( "Введите адрес доставки: " );
        string address = Console.ReadLine();
        _order.SetAddress( address );
    }
}

class Order
{
    private string _productName;
    private int _count;
    private string _name;
    private string _address;

    public void SetProductName( string productNamee )
    {
        _productName = productNamee;
    }

    public void SetCount( int count )
    {
        _count = count;
    }

    public void SetName( string name )
    {
        _name = name;
    }

    public void SetAddress( string address )
    {
        _address = address;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public int GetCount()
    {
        return _count;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetAddress()
    {
        return _address;
    }
}
