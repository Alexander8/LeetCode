public class Solution 
{
    public int[] FindRedundantConnection(int[][] edges) 
    {
        var nodes = new Dictionary<int, HashSet<int>>();
        var visited = new HashSet<int>();
        
        foreach (var edge in edges)
        {
            if (!nodes.TryGetValue(edge[0], out var set0))
            {
                set0 = new HashSet<int>();
                nodes.Add(edge[0], set0);
            }
            
            if (!nodes.TryGetValue(edge[1], out var set1))
            {
                set1 = new HashSet<int>();
                nodes.Add(edge[1], set1);
            }
            
            visited.Clear();
            if (set0.Count > 0 && set1.Count > 0 && DFS(nodes, visited, edge[0], edge[1]))
            {
                return edge;
            }
            
            set0.Add(edge[1]);
            set1.Add(edge[0]);
        }
        
        return null;
    }
    
    private static bool DFS(
        Dictionary<int, HashSet<int>> nodes, HashSet<int> visited,
        int start, int finish)
    {
        if (visited.Contains(start)) return false;
        
        visited.Add(start);
        
        if (start == finish) return true;
        
        if (!nodes.TryGetValue(start, out var neighbors))
            return false;
        
        foreach (var n in neighbors)
        {
            if (DFS(nodes, visited, n, finish))
                return true;
        }
        
        return false;
    }
}

public class Solution 
{
    public int[] FindRedundantConnection(int[][] edges) 
    {
        var dsu = new DisjointSetUnion(1000 + 1);
        foreach (var edge in edges) 
        {
            if (!dsu.Union(edge[0], edge[1])) 
                return edge;
        }

        return null;
    }
    
    public sealed class DisjointSetUnion
    {
        private readonly int[] _parent;
        private readonly int[] _rank;

        public DisjointSetUnion(int size)
        {
            _parent = new int[size];
            _rank = new int[size];

            for (var i = 0; i < _parent.Length; ++i)
                _parent[i] = i;
        }

        public int Find(int x)
        {
            if (_parent[x] != x) _parent[x] = Find(_parent[x]);
            return _parent[x];
        }

        public bool Union(int x, int y)
        {
            var xr = Find(x);
            var yr = Find(y);

            if (xr == yr) return false;

            if (_rank[xr] < _rank[yr]) 
            {
                _parent[xr] = yr;
            } 
            else if (_rank[xr] > _rank[yr]) 
            {
                _parent[yr] = xr;
            } 
            else 
            {
                _parent[yr] = xr;
                _rank[xr]++;
            }

            return true;
        }
    }
}