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
        string productName = _order.ProductName;
        int count = _order.Count;
        string name = _order.Name;
        string address = _order.Address;
        DateTime date = DateTime.Today.AddDays( 3 );

        Console.WriteLine( $"{name}! Ваш заказ {productName} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {date.ToShortDateString()}" );
    }
    public bool CheckOrder()
    {
        string productName = _order.ProductName;
        int count = _order.Count;
        string name = _order.Name;
        string address = _order.Address;

        Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {productName} на адрес {address}, все верно? Ответ в виде Да/Нет" );
        string answer = Console.ReadLine();
        return ( answer == "Да" );
    }
    public void InputData()
    {
        Console.WriteLine( "Введите название товара: " );
        string productName = Console.ReadLine();
        _order.ProductName = productName ;

        Console.WriteLine( "Введите количество товара: " );
        string countStr = Console.ReadLine();
        int count;
        while ( !int.TryParse( countStr, out count ) )
        {
            Console.WriteLine( "Неверные данные. Введите число" );
        }
        _order.Count = count;

        Console.WriteLine( "Введите ваше имя: " );
        string name = Console.ReadLine();
        _order.Name = name ;

        Console.WriteLine( "Введите адрес доставки: " );
        string address = Console.ReadLine();
        _order.Address = address ;
    }
}

class Order
{
    private string _productName;
    private int _count;
    private string _name;
    private string _address;

    public string ProductName
    {
        get { return _productName; }

        set { _productName = value; }
    }

    public int Count
    {
        get { return _count; }

        set { _count = value; }
    }
    public string Name
    {
        get { return _name; }

        set { _name = value; }
    }
    public string Address
    {
        get { return _address; }

        set { _address = value; }
    }
}
