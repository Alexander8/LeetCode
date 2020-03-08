public class Solution 
{
    public double FrogPosition(int n, int[][] edges, int t, int target) 
    {
        var q = new Queue<(int i, int t, double p)>();
        var map = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();

        for (var i = 0; i < edges.Length; ++i)
        {
            var start = Math.Min(edges[i][0], edges[i][1]);
            var finish = Math.Max(edges[i][0], edges[i][1]);

            if (!map.TryGetValue(start, out var lst))
            {
                lst = new List<int>();
                map.Add(start, lst);
            }

            lst.Add(finish);
        }

        q.Enqueue((1, 0, 1));
        visited.Add(1);

        while (q.Count > 0)
        {
            var p = q.Dequeue();
            if (p.i == target)
                return p.t == t || p.t < t && !map.ContainsKey(p.i) ? p.p : 0;

            if (map.ContainsKey(p.i))
            {
                foreach (var next in map[p.i])
                {
                    if (visited.Add(next))
                    {
                        q.Enqueue((next, p.t + 1, p.p * 1.0 / map[p.i].Count));
                    }
                }
            }
        }

        return 0;
    }
}