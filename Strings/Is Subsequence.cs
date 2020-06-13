// #1
public class Solution 
{
    public bool IsSubsequence(string s, string t) 
    {
        if (s.Length == 0) return true;
        
        int si = 0, ti = 0;
        
        while (ti < t.Length)
        {
            if (s[si] == t[ti])
            {
                ++si;
                if (si == s.Length) return true;
            }
            
            ++ti;
        }
        
        return false;
    }
}


// #2
public class Solution 
{
    public bool IsSubsequence(string s, string t) 
    {
        if (s.Length == 0) return true;
        
        var map = new List<int>[26];
        
        for (var i = 0; i < t.Length; ++i)
        {
            if (map[t[i] - 'a'] == null)
               map[t[i] - 'a'] = new List<int>();
            
            map[t[i] - 'a'].Add(i);
        }
        
        var prev = -1;
        for (var i = 0; i < s.Length; ++i)
        {
            if (map[s[i] - 'a'] == null)
                return false;
            
            var idx = map[s[i] - 'a'].BinarySearch(prev);
            if (idx < 0) idx = ~idx;
            
            if (idx == map[s[i] - 'a'].Count) return false;
            
            prev =  map[s[i] - 'a'][idx];
            ++prev;
        }
        
        return true;
    }
}