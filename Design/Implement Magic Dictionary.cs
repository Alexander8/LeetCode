public class MagicDictionary 
{
    private readonly Dictionary<string, HashSet<string>> _map = new Dictionary<string, HashSet<string>>();
    
    public MagicDictionary() 
    {        
    }

    public void BuildDict(string[] dict) 
    {   
        foreach (var word in dict)
        {
            for (var i = 0; i < word.Length; ++i)
            {
                var sb = new StringBuilder(word);
                sb[i] = '*'; 
                var key = sb.ToString();
                
                if (!_map.TryGetValue(key, out var set))
                {
                    set = new HashSet<string>();
                    _map.Add(key, set);
                }
                
                set.Add(word);
            }
        }
    }
    
    public bool Search(string word)
    {         
        for (var i = 0; i < word.Length; ++i)
        {
            var sb = new StringBuilder(word);
            sb[i] = '*';

            if (_map.TryGetValue(sb.ToString(), out var set) && (set.Count > 1 || !set.Contains(word)))
                return true;            
        }
        
        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dict);
 * bool param_2 = obj.Search(word);
 */