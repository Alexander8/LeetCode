public class Solution 
{
    public int NumSimilarGroups(string[] A) 
    {
        var dsu = new DisjointSetUnion(A.Length);
        
        for (var i = 0; i < A.Length; ++i)
            for (var j = i + 1; j < A.Length; ++j)
                if (AreSimilar(A[i], A[j]))
                    dsu.Union(i, j);
        
        var set = new HashSet<int>();
        for (var i = 0; i < A.Length; ++i)
            set.Add(dsu.Find(i));
        
        return set.Count;
    }
    
    private static bool AreSimilar(string x, string y)
    {
        var cnt = 0;
        
        for (var i = 0; i < x.Length; ++i)
        {
            if (x[i] != y[i])
            {
                ++cnt;
                if (cnt > 2) return false;
            }
        }
        
        return cnt == 0 || cnt == 2;
    }
    
    private sealed class DisjointSetUnion
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