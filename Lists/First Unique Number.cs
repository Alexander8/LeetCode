public class FirstUnique 
{
    private readonly LinkedList<int> _q = new LinkedList<int>();
    private readonly Dictionary<int, LinkedListNode<int>> _map = new Dictionary<int, LinkedListNode<int>>();
    
    public FirstUnique(int[] nums) 
    {
        foreach (var num in nums)
            Add(num);
    }
    
    public int ShowFirstUnique() 
    {
        return _q.Count > 0 ? _q.First.Value : -1;    
    }
    
    public void Add(int value) 
    {
        if (_map.TryGetValue(value, out var node))
        {
            if (node != null)
                _q.Remove(node);
            
            _map[value] = null;
        }
        else
        {
            node = _q.AddLast(value);
            _map[value] = node;
        }
    }
}

/**
 * Your FirstUnique object will be instantiated and called as such:
 * FirstUnique obj = new FirstUnique(nums);
 * int param_1 = obj.ShowFirstUnique();
 * obj.Add(value);
 */