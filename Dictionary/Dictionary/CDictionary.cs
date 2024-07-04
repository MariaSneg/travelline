class CDictionary
{
    private Dictionary<string, string> _dict = new Dictionary<string, string>();
    private bool _isReverse;
    private bool _isChanged = false;

    public CDictionary( bool IsReverse ) 
    {
        _isReverse = IsReverse;
    }

   public void ParseDictionary(string NameFile)
    {
        StreamReader file = new StreamReader(NameFile);
        string line = file.ReadLine();
        while (line != null)
        {
            string[] parts = line.Split( ':' );
            if (_isReverse)
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

    public string TranslateWord(string word)
    {
        if(_dict.TryGetValue(word, out string translation))
        {
            return translation; 
        }
        return "";
    }

    public void AddNewWord(string word, string translation )
    {
        if (!string.IsNullOrEmpty(translation) && !string.IsNullOrEmpty( translation ) )
        {
            if (_isReverse)
            {
                _dict[ translation ] = word; 
                return;
            }
            _dict[ word ] = translation;
            _isChanged = true;
        }
        else
        {
            Console.WriteLine( "Слово проигнорировано" );
        }
    }

    public void SaveChanges(string NameFile)
    {
        if(_isChanged)
        {
            StreamWriter file = new StreamWriter(NameFile);
            foreach (var translate in _dict )
            {
                file.WriteLine($"{translate.Key}:{translate.Value}");
            }
        }
    }
}