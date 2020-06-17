public class TreeAncestor 
{
    private readonly Dictionary<int, List<int>> _map = new Dictionary<int, List<int>>();
    private readonly int[] _arr = null;
    
    public TreeAncestor(int n, int[] parent) 
    {
        var isLine = true;
        for (var i = 1; i < n; ++i)
        {
            if (parent[i] != i - 1)
            {
                isLine = false;
                break;
            }
        }
        
        if (isLine)
        {
            _arr = parent;
        }
        else
        {        
            _map[0] = new List<int>();

            for (var i = 1; i < n; ++i)
            {
                var parents = new List<int>()
                {
                    parent[i]
                };

                parents.AddRange(_map[parent[i]]);

                _map[i] = parents;
            }
        }
    }
    
    public int GetKthAncestor(int node, int k) 
    {
        if (_arr == null)
        {        
            if (!_map.TryGetValue(node, out var parents))
                return -1;

            if (parents.Count < k)
                return -1;

            return parents[k - 1];
        }
        else
        {
            if (node + 1 - k < 0) return -1;
            
            return _arr[node + 1 - k];
        }
    }
}

/**
 * Your TreeAncestor object will be instantiated and called as such:
 * TreeAncestor obj = new TreeAncestor(n, parent);
 * int param_1 = obj.GetKthAncestor(node,k);
 */