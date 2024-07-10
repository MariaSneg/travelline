CDictionary engToRusDict = new CDictionary( false );
CDictionary rusToEngDict = new CDictionary( true );

string fileName = "C:\\Programming\\travalline\\Dictionary\\Dictionary\\dict.txt";
engToRusDict.ParseDictionary( fileName );
rusToEngDict.ParseDictionary( fileName );

string command = "";
while ( command != "3" )
{
    PrintMenu();
    command = Console.ReadLine();
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
engToRusDict.SaveChanges( fileName );


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
    string word = Console.ReadLine().ToLower();

    string translation = engToRusDict.TranslateWord( word );
    if ( translation == "" )
    {
        translation = rusToEngDict.TranslateWord( word );
        if ( translation == "" )
        {
            Console.WriteLine( "Неизвестное слово. Добавить его в словарь? Для согласия введите Y или y" );
            string answer = Console.ReadLine().ToLower();
            if ( answer == "y" )
            {
                NewWord();
            }
            else
            {
                Console.WriteLine( "Слово проигнорировано" );
            }
        }
    }
}

void NewWord()
{
    Console.WriteLine( "Введите новое слово на английском" );
    string newWord = Console.ReadLine();

    Console.WriteLine( "Введите слово на русском" );
    string newTranslation = Console.ReadLine();

    if ( engToRusDict.AddNewWord( newWord, newTranslation ) && rusToEngDict.AddNewWord( newWord, newTranslation ) )
    {
        Console.WriteLine( "Слово добавлено в словарь" );
    }
}