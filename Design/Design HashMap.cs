public class MyHashMap 
{
    private readonly Entry[] _entries = new Entry[10_000];
    
    public MyHashMap() 
    {        
    }
    
    public void Put(int key, int value) 
    {
        var hash = key % _entries.Length;
        if (_entries[hash] == null)
            _entries[hash] = new Entry();
        
        _entries[hash].Add(key, value);       
    }
    
    public int Get(int key) 
    {
        var hash = key % _entries.Length;
        return _entries[hash]?.Get(key) ?? -1;
    }
    
    public void Remove(int key) 
    {
        var hash = key % _entries.Length;
        _entries[hash]?.Remove(key);
    }
    
    private sealed class Entry
    {        
        private readonly List<(int key, int value)> Values = new List<(int, int)>();
        
        public void Add(int key, int value)
        {
            var idx = Values.FindIndex(x => x.key == key);
            if (idx < 0)
                Values.Add((key, value));
            else
                Values[idx] = (key, value);
        }
        
        public int Get(int key)
        {
            var idx = Values.FindIndex(x => x.key == key);
            return idx >= 0 ? Values[idx].value : -1;
        }
        
        public void Remove(int key)
        {
            var idx = Values.FindIndex(x => x.key == key);
            if (idx >= 0)
                Values.RemoveAt(idx);
        }
    }
}