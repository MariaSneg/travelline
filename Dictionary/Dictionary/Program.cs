Dictionary dict = new Dictionary();

string fileName = "dict.txt";
dict.ParseDictionary( fileName );

string command = "";
while ( command != "3" )
{
    PrintMenu();
    command = ReadNonEmptyInput();
    switch ( command )
    {
        case "1":
            TranslateWord();
            break;
        case "2":
            NewWord();
            break;
        case "3":
            break;
        default:
            Console.WriteLine( "Неизвестная команда" );
            break;
    }
}
dict.SaveChanges( fileName );


void PrintMenu()
{
    Console.WriteLine( "Выберите номер команды:" );
    Console.WriteLine( "1: перевод слова" );
    Console.WriteLine( "2: добавление нового слова" );
    Console.WriteLine( "3: выход" );
}

void TranslateWord()
{
    Console.WriteLine( "Введите слово:" );
    string word = ReadNonEmptyInput().ToLower();

    string translation = dict.TranslateWord( word );
    if ( string.IsNullOrWhiteSpace( translation ) )
    {
        Console.WriteLine( "Неизвестное слово. Добавить его в словарь? Для согласия введите Y или y" );
        string answer = ReadNonEmptyInput().ToLower();
        if ( answer == "y" )
        {
            NewWord();
            return;
        }
        Console.WriteLine( "Слово проигнорировано" );
        return;
    }
    Console.WriteLine( translation );
}

void NewWord()
{
    Console.WriteLine( "Введите новое слово на английском" );
    string newWord = ReadNonEmptyInput();

    Console.WriteLine( "Введите слово на русском" );
    string newTranslation = ReadNonEmptyInput();

    if ( dict.AddNewWord( newWord, newTranslation ) )
    {
        Console.WriteLine( "Слово добавлено в словарь" );
    }
}

string ReadNonEmptyInput()
{
    string input;
    do
    {
        input = Console.ReadLine();
        if ( string.IsNullOrWhiteSpace( input ) )
        {
            Console.WriteLine( "Ввод не может быть пустым" );
        }
    } while ( string.IsNullOrWhiteSpace( input ) );

    return input;
}