public class Solution 
{
    public int NumMatchingSubseq(string S, string[] words) 
    {
        var cnt = 0;
        var cache = new Dictionary<string, bool>();
        
        foreach (var w in words)
        {
            if (w.Length > S.Length)
                continue;
            
            if (IsSubSeq(S, w, cache))
                ++cnt;
        }
        
        return cnt;
    }
    
    private static bool IsSubSeq(string s, string w, Dictionary<string, bool> cache)
    {
        if (cache.TryGetValue(w, out var cached))
            return cached;
        
        var curr = 0;
        
        for (var i = 0; i < s.Length; ++i)
        {
            if (s[i] == w[curr])
            {
                ++curr;
                if (curr == w.Length)
                    break;
            }
        }
        
        cache.Add(w, curr == w.Length);
        
        return curr == w.Length;
    }
}