public class Solution 
{
    public IList<bool> CamelMatch(string[] queries, string pattern) 
    {
        var res = new bool[queries.Length];
        
        for (var i = 0; i < queries.Length; ++i)
        {
            var idx = 0;
            var match = true;
            
            foreach (var c in queries[i])
            {
                if (char.IsLower(c))
                {
                    if (idx < pattern.Length && c == pattern[idx])
                        ++idx;
                    
                    continue;
                }
                
                if (idx == pattern.Length)
                {
                    match = false;
                    break;
                }
                
                if (c == pattern[idx])
                {
                    ++idx;
                    continue;
                }
                else
                {
                    match = false;
                    break;
                }
            }
            
            res[i] = idx == pattern.Length && match;
        }
        
        return res;
    }
}