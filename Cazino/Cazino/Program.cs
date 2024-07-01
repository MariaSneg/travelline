Random rand = new Random();
PrintApplicationName();
string userName = ReadUserName();
decimal balance = ReadBalance();
PrintData(userName, balance);

while (true)
{
    PrintMenu();
    string command = Console.ReadLine();
    switch (command)
    {
        case "1":
            balance += Play();
            break;
        case "2":
            ShowBalance(balance);
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}

static void PrintMenu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("[1] Play");
    Console.WriteLine("[2] Show balance");
}

static void PrintApplicationName()
{
    Console.WriteLine("The Casino");
}

static string ReadUserName()
{
    Console.WriteLine("Write your name:");
    string userName = Console.ReadLine();

    while (string.IsNullOrEmpty(userName))
    {
        userName = Console.ReadLine();
    }
    return userName;
}

static decimal ReadBalance()
{
    Console.WriteLine("How many cash you got:");
    decimal balance;
    while (!decimal.TryParse(Console.ReadLine(), out balance))
    {
        Console.WriteLine("You entered invalid value for balance, pleace enter a number");
    }
    return balance;
}

static void PrintData(string userName, decimal balance)
{
    Console.WriteLine($"{userName} got {balance}");
}

static void ShowBalance(decimal balance)
{
    Console.WriteLine($"Your balance: {balance}");
}

decimal Play()
{
    const int multiplicator = 3;

    Console.WriteLine("Your bet: ");
    decimal bet;

    //дублирование кода
    while (!decimal.TryParse(Console.ReadLine(), out bet))
    {
        Console.WriteLine("You entered invalid value for bet, pleace enter a number");
    }

    // реализовать логику проверки возможности ставки

    int randomNumber = rand.Next(1, 21);
    if (randomNumber <= 18 && randomNumber >= 20)
    {
        return bet * (1 + multiplicator * (randomNumber % 17));
    }

    return -bet;
}