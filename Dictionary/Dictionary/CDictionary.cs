class CDictionary
{
    private Dictionary<string, string> _dict = new Dictionary<string, string>();
    private bool _isReverse;
    private bool _isChanged = false;

    public CDictionary( bool IsReverse )
    {
        _isReverse = IsReverse;
    }

    public void ParseDictionary( string fileName )
    {
        using ( StreamReader file = new StreamReader( fileName ) )
        {
            string line = file.ReadLine();
            while ( line != null )
            {
                string[] parts = line.Split( ':' );
                if ( _isReverse )
                {
                    _dict[ parts[ 1 ] ] = parts[ 0 ];
                }
                else
                {
                    _dict[ parts[ 0 ] ] = parts[ 1 ];
                }
                line = file.ReadLine();
            }
        }
    }

    public string TranslateWord( string word )
    {
        if ( _dict.TryGetValue( word, out string translation ) )
        {
            return translation;
        }
        return "";
    }

    public bool AddNewWord( string word, string translation )
    {
        if ( !string.IsNullOrEmpty( translation ) && !string.IsNullOrEmpty( translation ) )
        {
            if ( _dict.ContainsKey( word ) )
            {
                Console.WriteLine( "Слово уже есть в словаре" );
                return false;
            }
            if ( _isReverse )
            {
                _dict[ translation ] = word;
                return true;
            }
            _dict[ word ] = translation;
            _isChanged = true;
        }
        else
        {
            Console.WriteLine( "Слово проигнорировано" );
        }
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