CDictionary engToRusDict = new CDictionary( false );
CDictionary rusToEngDict = new CDictionary( true );

string fileName = "C:\\Programming\\travalline\\Dictionary\\Dictionary\\dict.txt";
engToRusDict.ParseDictionary( fileName );
rusToEngDict.ParseDictionary( fileName );

Console.WriteLine( "Для выхода введите '...'" );
string word;
while ( true )
{
    word = Console.ReadLine();
    if ( word == "..." )
    {
        engToRusDict.SaveChanges( fileName );
        break;
    }

    string translation = engToRusDict.TranslateWord( word );
    if ( translation == "" )
    {
        translation = rusToEngDict.TranslateWord( word );
        if ( translation == "" )
        {
            NewWord();
            continue;
        }
    }
    Console.WriteLine( translation );
}

void NewWord()
{
    Console.WriteLine( "Неизвестное слово. Добавить его в словарь? Для согласия введите Y или y" );
    string answer = Console.ReadLine();
    if ( answer == "y" )
    {
        Console.WriteLine( "Введите новое слово на английском" );
        string newWord = Console.ReadLine();
        Console.WriteLine( "Введите слово на русском" );
        string newTranslation = Console.ReadLine();
        engToRusDict.AddNewWord( newWord, newTranslation );
        rusToEngDict.AddNewWord( newWord, newTranslation );
        Console.WriteLine( "Слово добавлено в словарь" );
    }
    else
    {
        Console.WriteLine( "Слово проигнорировано" );
    }
}