public class Solution 
{
    public int MakeConnected(int n, int[][] connections) 
    {
        var dsu = new DisjointSetUnion(n);
        var segments = new Dictionary<int, int>();
        var edges = new Dictionary<int, int>();
        
        foreach (var c in connections)
            dsu.Union(c[0], c[1]);
        
        for (var i = 0; i < n; ++i)
        {                
            var parent = dsu.Find(i);
            if (!segments.TryGetValue(parent, out var cnt))
                cnt = 0;
            
            segments[parent] = cnt + 1;
        }
        
        foreach (var c in connections)
        {
            var parent = dsu.Find(c[0]);
            if (!edges.TryGetValue(parent, out var cnt))
                cnt = 0;
            
            edges[parent] = cnt + 1;
        }
        
        var freeCabels = 0;
        
        foreach (var segment in segments)
        {
            var minCabelsRequired = segment.Value - 1;   
            var actualCabels = edges.TryGetValue(segment.Key, out var segmentEdges) ? segmentEdges : 0;

            freeCabels += minCabelsRequired > actualCabels ? 0 : actualCabels - minCabelsRequired;
        }

        return freeCabels < segments.Count - 1 ? -1 : segments.Count - 1;
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