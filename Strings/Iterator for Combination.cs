public class CombinationIterator 
{
    private readonly List<string> _combinations = new List<string>();
    private int _idx = 0;
    
    public CombinationIterator(string characters, int combinationLength) 
    {
        var cnt = (int)Math.Pow(2, characters.Length) - 1;
        var chars = new char[combinationLength];
        
        while (cnt >= 1)
        {
            var charIdx = 0;
            var result = true;

            for (var i = characters.Length - 1; i >= 0; --i)
            {
                var test = 1 << i;
                if ((cnt & test) != 0)
                {
                    if (charIdx == combinationLength)
                    {
                        result = false;
                        break;
                    }

                    chars[charIdx] = characters[characters.Length - 1 - i];
                    ++charIdx;
                }
            }

            if (charIdx == combinationLength && result)
                _combinations.Add(new string(chars));

            --cnt;
        }
    }
    
    public string Next() 
    {
        return _combinations[_idx++];
    }
    
    public bool HasNext() 
    {
        return _idx < _combinations.Count;
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * string param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */