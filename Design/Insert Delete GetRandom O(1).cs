public class RandomizedSet 
{
    private readonly Dictionary<int, int> _map = new Dictionary<int, int>();
    private readonly List<int> _items = new List<int>();
    private readonly Random _rand = new Random();

    /** Initialize your data structure here. */
    public RandomizedSet() 
    {        
    }

    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) 
    {
        if (!_map.ContainsKey(val))
        {
            _map.Add(val, _items.Count);
            _items.Add(val);
            return true;
        }
        
        return false;
    }

    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) 
    {
        if (_map.TryGetValue(val, out var idx))
        {
            _map.Remove(val);
            
            if (idx < _items.Count - 1)
            {
                var last = _items[_items.Count - 1];
                _items[idx] = last;
                _map.Remove(last);
                _map.Add(last, idx);
            }
            
            _items.RemoveAt(_items.Count - 1); 
            return true;
        }
        
        return false;
    }

    /** Get a random element from the set. */
    public int GetRandom() 
    {
        var idx = _rand.Next(0, _items.Count);
        return _items[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */