public class RandomizedCollection 
{
    private readonly List<int> _vals = new List<int>();
    private readonly Dictionary<int, HashSet<int>> _valToIdxs = new Dictionary<int, HashSet<int>>();
    private readonly Random _rand = new Random();
    
    
    /** Initialize your data structure here. */
    public RandomizedCollection() 
    {        
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) 
    {
        if (!_valToIdxs.TryGetValue(val, out var idxs))
        {
            idxs = new HashSet<int>();
            _valToIdxs.Add(val, idxs);
        }
        
        idxs.Add(_vals.Count);
        _vals.Add(val);
               
        return idxs.Count == 1;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) 
    {
        if (!_valToIdxs.TryGetValue(val, out var idxs) || idxs.Count == 0)
            return false;
        
        var idx = idxs.First();
        idxs.Remove(idx);
        
        var lastVal = _vals[_vals.Count - 1];
        
        _valToIdxs[lastVal].Add(idx);
        _valToIdxs[lastVal].Remove(_vals.Count - 1);
        
        _vals[idx] = lastVal;
        _vals.RemoveAt(_vals.Count - 1);

        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() 
    {
        var idx = _rand.Next(_vals.Count);
        return _vals[idx];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */