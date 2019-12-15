public int UniqueLetterString(string S) 
{      
    long cnt = 0L;
    long modulo = 1000000000L + 7L;
    
    var map = new Dictionary<char, List<int>>();
    
    for (var i = 0; i < S.Length; ++i)
    {
        var c = S[i];
        
        if (!map.TryGetValue(c, out var list))
        {
            list = new List<int>();
            map.Add(c, list);
        }
        
        list.Add(i);
    }       
    
    foreach (var item in map)
    {
        var list = item.Value;
        
        for (var i = 0; i < list.Count; ++i)
        {                
            var prev = i > 0 ? list[i - 1] : -1;
            var next = i + 1 < list.Count ? list[i + 1] : S.Length;
            
            cnt += (list[i] - prev) * (next - list[i]);
        }
    }
    
    return (int)(cnt % modulo);
}