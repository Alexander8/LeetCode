public class TimeMap 
{
    private readonly Dictionary<string, List<(int Timestamp, string Value)>> _map = 
        new Dictionary<string, List<(int Timestamp, string Value)>>();
    private readonly Comparer _comparer = new Comparer();
        
    public TimeMap() 
    {  
    }
    
    public void Set(string key, string value, int timestamp) 
    {
        if (!_map.TryGetValue(key, out var list))
        {
            list = new List<(int, string)>();
            _map.Add(key, list);
        }
        
        list.Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) 
    {
        if (!_map.TryGetValue(key, out var list))
            return string.Empty;
        
        var idx = list.BinarySearch((timestamp, string.Empty), _comparer);
        if (idx >= 0)
            return list[idx].Value;
        
        idx = ~idx;
        
        return idx - 1 >= 0 ? list[idx - 1].Value : string.Empty;
    }
    
    private sealed class Comparer: IComparer<(int Timestamp, string)>
    {
        public int Compare((int Timestamp, string) x, (int Timestamp, string) y)
        {
            return x.Timestamp - y.Timestamp;
        }
    }
}
