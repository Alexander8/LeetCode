public class Solution 
{
    public IList<string> TopKFrequent(string[] words, int k) 
    {
        if (k == 0) return new List<string>();
        
        var res = new List<string>();
        var wToF = new Dictionary<string, int>();
        var fToW = new Dictionary<int, List<string>>();
        var comparer = new Comparer();
        var maxF = 0;
        
        foreach (var w in words)
        {
            var f = wToF.GetValueOrDefault(w, 0);
            wToF[w] = f + 1;
            maxF = Math.Max(maxF, f + 1);
        }
        
        foreach (var item in wToF)
        {
            if (!fToW.TryGetValue(item.Value, out var list))
            {
                list = new List<string>();
                fToW.Add(item.Value, list);
            }
            
            var idx = list.BinarySearch(item.Key, comparer);
            if (idx < 0) idx = ~idx;
            list.Insert(idx, item.Key);
        }
        
        for (var f = maxF; f >= 1; --f)
        {
            if (fToW.TryGetValue(f, out var list))
            {                
                foreach (var w in list)
                {
                    res.Add(w);
                    if (res.Count == k) return res;
                }
            }
        }
        
        return res;
    }
    
    private sealed class Comparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }
    }
}