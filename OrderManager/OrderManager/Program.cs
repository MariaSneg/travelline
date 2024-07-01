OrderManager orderManager = new OrderManager();
orderManager.InputData();
while (!orderManager.CheckOrder())
{
    Console.WriteLine("Введите данные еще раз");
    orderManager.InputData();
}
orderManager.SuccessfulOrdering();

class OrderManager
{
    private Order m_order = new Order();


    public void SuccessfulOrdering()
    {
        string productName = m_order.GetProductName();
        int count = m_order.GetCount();
        string name = m_order.GetName();
        string address = m_order.GetAddress();

        Console.WriteLine($"{name}! Ваш заказ {productName} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {{todays_date + 3_days}}");
    }
    public bool CheckOrder()
    {
        string productName = m_order.GetProductName();
        int count = m_order.GetCount();
        string name = m_order.GetName();
        string address = m_order.GetAddress();

        Console.WriteLine($"Здравствуйте, {name}, вы заказали {count} {productName} на адрес {address}, все верно? Ответ в виде Да/Нет");
        string answer = Console.ReadLine();
        return (answer == "Да") ? true : false;
    }
    public void InputData()
    {
        Console.WriteLine("Введите название товара: ");
        string productName = Console.ReadLine();
        m_order.SetProductName(productName);

        Console.WriteLine("Введите количество товара: ");
        string countStr = Console.ReadLine();
        if(int.TryParse(countStr, out int count))
        {
            m_order.SetCount(count);
        }
        else
        {
            Console.WriteLine("Неверные данные. Введите число");
        }

        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();
        m_order.SetName(name);

        Console.WriteLine("Введите адрес доставки: ");
        string address = Console.ReadLine();
        m_order.SetAddress(address);
    }
}

class Order
{
    public string m_productName;
    public int m_count;
    public string m_name;
    public string m_address;

    public void SetProductName(string productNamee)
    {
        m_productName = productNamee;
    }

    public void SetCount(int count)
    {
        m_count = count;
    }

    public void SetName(string name)
    {
        m_name = name;
    }

    public void SetAddress(string address)
    {
        m_address = address;
    }

    public string GetProductName()
    {
        return m_productName;
    }

    public int GetCount()
    {
        return m_count;
    }
    public string GetName()
    {
        return m_name;
    }
    public string GetAddress()
    {
        return m_address;
    }
}
