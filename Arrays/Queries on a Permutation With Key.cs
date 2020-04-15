public class Solution 
{
    public int[] ProcessQueries(int[] queries, int m) 
    {
        var res = new int[queries.Length];
        var p = new List<int>(m);
        var map = new Dictionary<int, int>();

        for (var i = 0; i < m; ++i)
        {
            p.Add(i + 1);
            map[i + 1] = i;
        }

        for (var i = 0; i < queries.Length; ++i)
        {
            var x = queries[i];
            var pos = map[x];
            res[i] = pos;

            for (var j = 0; j < pos; ++j)
                map[p[j]] = j + 1;

            map[x] = 0;

            p.RemoveAt(pos);
            p.Insert(0, x);
        }

        return res;
    }
}