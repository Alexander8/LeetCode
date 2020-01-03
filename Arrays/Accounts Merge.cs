public class Solution 
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) 
    {
        var dsu = new DisjointSetUnion(10001);
        var emailIds = new Dictionary<string, int>();
        var emailNames = new Dictionary<string, string>();
        var id = 0;
        
        foreach (var account in accounts)
        {
            var name = account[0];
            
            for (var i = 1; i < account.Count; ++i)
            {
                var email = account[i];
                emailNames[email] = name;
                
                if (!emailIds.ContainsKey(email))
                {
                    ++id;
                    emailIds.Add(email, id);
                }
                
                dsu.Union(emailIds[account[1]], emailIds[email]);
            }
        }
        
        var res = new Dictionary<int, IList<string>>();
        
        foreach (var email in emailNames.Keys)
        {
            var emailId = dsu.Find(emailIds[email]);
            if (!res.TryGetValue(emailId, out var account))
            {
                account = new List<string>();
                res.Add(emailId, account);
            }
            
            account.Add(email);
        }
        
        foreach (List<string> account in res.Values)
        {
            account.Sort((string left, string right) => string.CompareOrdinal(left, right));
            account.Insert(0, emailNames[account[0]]);
        }
        
        return res.Values.ToList();
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