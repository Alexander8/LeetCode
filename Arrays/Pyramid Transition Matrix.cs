public class Solution 
{
    public bool PyramidTransition(string bottom, IList<string> allowed) 
    {
        var map = new Dictionary<string, HashSet<char>>();
        
        foreach (var item in allowed)
        {
            var pair = item.Substring(0, 2);          
            if (!map.TryGetValue(pair, out var set))
            {
                set = new HashSet<char>();
                map.Add(pair, set);
            }
            
            set.Add(item[2]);
        }
        
        return PyramidTransition(bottom, new HashSet<string>(), map);
    }
    
    private static bool PyramidTransition(string bottom, HashSet<string> cache, Dictionary<string, HashSet<char>> map)
    {
        if (bottom.Length == 1) return true;
        
        if (cache.Contains(bottom)) return false;
        
        cache.Add(bottom);
        
        var bottoms = new List<string>();
        
        for (var i = 0; i < bottom.Length - 1; ++i)
        {
            var pair = bottom.Substring(i, 2);   
            if (!map.TryGetValue(pair, out var set))
                return false;    
            
            if (bottoms.Count == 0)
            {
                foreach (var letter in set)
                    bottoms.Add(letter.ToString());
            }
            else
            {
                var bottomsTmp = new List<string>(bottoms.Count * set.Count);
            
                foreach (var letter in set)
                {
                    foreach (var b in bottoms)
                        bottomsTmp.Add(b + letter);
                }
                
                bottoms = bottomsTmp;
            }           
        }
        
        foreach (var b in bottoms)
        {
            if (PyramidTransition(b, cache, map))
                return true;
        }
        
        return false;
    }
}