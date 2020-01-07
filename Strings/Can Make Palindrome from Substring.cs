public class Solution 
{
    public IList<bool> CanMakePaliQueries(string s, int[][] queries) 
    {
        var res = new List<bool>(queries.Length);
        var map = new Dictionary<int, Dictionary<char, int>>();
        map[s.Length - 1] = s.GroupBy(c => c).ToDictionary(gr => gr.Key, gr => gr.Count());
        
        for (var i = s.Length - 2; i >= 0; --i)
        {
            var m = new Dictionary<char, int>(map[i + 1]);
            m[s[i + 1]] -= 1;
            map[i] = m;
        }
        
        foreach (var q in queries)
        {
            var minRepl = MinReplacements(map, q[0], q[1]);       
            res.Add(minRepl <= q[2]);
            
        }
        
        return res;
    }
    
    private static int MinReplacements(Dictionary<int, Dictionary<char, int>> map, int start, int end)
    {
        var cnt = 0;
        var map1 = start - 1 >= 0 ? map[start - 1] : new Dictionary<char, int>();
        var map2 = new Dictionary<char, int>(map[end]);
        
        foreach (var p in map1)
        {
            map2[p.Key] -= p.Value;
        }
        
        foreach (var c in map2.Values)
        {
            if (c % 2 == 1)
                ++cnt;
        }
        
        if ((end - start + 1) % 2 == 1)
            --cnt;
        
        return cnt / 2;
    }
}