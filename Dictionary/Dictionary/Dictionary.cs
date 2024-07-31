public class Dictionary
{
    private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();
    private readonly Dictionary<string, string> _reverseDict = new Dictionary<string, string>();
    private bool _isChanged = false;

    public void ParseDictionary( string fileName )
    {
        using ( StreamReader file = new StreamReader( fileName ) )
        {
            string line = file.ReadLine();
            while ( line != null )
            {
                string[] parts = line.Split( ':' );
                _dict[ parts[ 0 ] ] = parts[ 1 ];
                _reverseDict[ parts[ 1 ] ] = parts[ 0 ];
                line = file.ReadLine();
            }
        }
    }

    public string TranslateWord( string word )
    {
        string translation;
        if ( !_dict.TryGetValue( word, out translation ) && !_reverseDict.TryGetValue( word, out translation ) )
        {
            return string.Empty;
        }
        return translation;
    }

    public bool AddNewWord( string word, string translation )
    {
        if ( string.IsNullOrEmpty( word ) || string.IsNullOrEmpty( translation ) )
        {
            Console.WriteLine( "Слово проигнорировано" );
            return false;
        }
        if ( _dict.ContainsKey( word ) )
        {
            Console.WriteLine( "Слово уже есть в словаре" );
            return false;
        }
        _reverseDict[ translation ] = word;
        _dict[ word ] = translation;
        _isChanged = true;
        return true;
    }

    public void SaveChanges( string fileName )
    {
        if ( _isChanged )
        {
            using ( StreamWriter file = new StreamWriter( fileName ) )
            {
                foreach ( var translate in _dict )
                {
                    file.WriteLine( $"{translate.Key}:{translate.Value}" );
                }
            }
        }
    }
}