public class AllOne 
{
    private readonly Dictionary<string, int> _keyMap = new Dictionary<string, int>();
    private readonly Dictionary<int, Node> _nodeMap = new Dictionary<int, Node>();
    private Node _head;
    private Node _tail;
    
    /** Initialize your data structure here. */
    public AllOne() 
    {
        _head = new Node { Val = int.MinValue };
        _tail = new Node { Val = int.MaxValue };
        
        _head.Next = _tail;
        _tail.Prev = _head;
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key) 
    {
        if (_keyMap.TryGetValue(key, out var val))
        {
            ChangeValue(key, true);
        }
        else
        {
            _keyMap[key] = 1;
            if (_head.Next.Val != 1)
            {
                InsertNodeAfter(_head, new Node { Val = 1 });
                _nodeMap[1] = _head.Next;
            }
            
            _head.Next.Keys.Add(key);            
        }
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key) 
    {
        if (_keyMap.TryGetValue(key, out var val))
        {
            if (val == 1)
            {
                _keyMap.Remove(key);
                var node = _nodeMap[1];
                
                node.Keys.Remove(key);
                if (node.Keys.Count == 0)
                {
                    RemoveNode(node);
                    _nodeMap.Remove(node.Val);
                }
            }
            else
            {
                ChangeValue(key, false);
            }
        }
    }
    
    /** Returns one of the keys with maximal value. */
    public string GetMaxKey() 
    {
        return _tail.Prev != _head ? _tail.Prev.Keys.First() : string.Empty;
    }
    
    /** Returns one of the keys with Minimal value. */
    public string GetMinKey() 
    {
        return _head.Next != _tail ? _head.Next.Keys.First() : string.Empty;
    }
    
    private void ChangeValue(string key, bool inc)
    {
        var oldValue = _keyMap[key];
        var newValue = inc ? oldValue + 1 : oldValue - 1;
        
        _keyMap[key] = newValue;
        
        var oldNode = _nodeMap[oldValue];
        if (newValue > oldValue)
        {
            if (oldNode.Next.Val != newValue)
            {
                var newNode = new Node { Val = newValue };
                newNode.Keys.Add(key);
                
                InsertNodeAfter(oldNode, newNode);
                _nodeMap[newValue] = newNode;
            }
            else
            {
                oldNode.Next.Keys.Add(key);
            }
        }
        else
        {
            if (oldNode.Prev.Val != newValue)
            {
                var newNode = new Node { Val = newValue };
                newNode.Keys.Add(key);
                
                InsertNodeAfter(oldNode.Prev, newNode);
                _nodeMap[newValue] = newNode;
            }
            else
            {
                oldNode.Prev.Keys.Add(key);
            }
        }        
        
        oldNode.Keys.Remove(key);       
        if (oldNode.Keys.Count == 0)
        {
            RemoveNode(oldNode);
            _nodeMap.Remove(oldNode.Val);
        }
    }
    
    private static void InsertNodeAfter(Node firstNode, Node newNode)
    {
        firstNode.Next.Prev = newNode;
        newNode.Next = firstNode.Next;
        firstNode.Next = newNode;
        newNode.Prev = firstNode;
    }
    
    private static void RemoveNode(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
    
    private sealed class Node
    {
        public Node Prev;
        public Node Next;
        public int Val;
        public HashSet<string> Keys = new HashSet<string>();
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */