public class Solution 
{
    public int ShortestPath(int[][] grid, int k) 
    {
        var q = new SortedList<int, List<(int x, int y, int z)>>();
        var visited = new Dictionary<(int x, int y), int>();
        var distances = new Dictionary<(int x, int y, int z), int>();
        var t = (grid.Length - 1, grid[grid.Length - 1].Length - 1);
        
        q.Add(0, new List<(int x, int y, int z)>());
        q[0].Add((0, 0, k));
        
        visited.Add((0, 0), k);
        
        distances[(0, 0, k)] = 0;
        
        while (q.Count > 0)
        {
            var points = q[q.Keys.First()];
            var p = points[0];
            
            if (points.Count == 1) q.Remove(q.Keys.First());
            else points.RemoveAt(0);
            
            foreach (var n in GetNeighbors(grid, p.x, p.y, p.z))
            {
                distances[n] = Math.Min(distances[p] + 1, distances.ContainsKey(n) ? distances[n] : int.MaxValue);
                
                if (visited.TryGetValue((n.x, n.y), out var kk) && kk >= n.z)
                    continue;
                
                if (!q.ContainsKey(distances[n]))
                    q[distances[n]] = new List<(int x, int y, int z)>();

                q[distances[n]].Add(n);

                visited[(n.x, n.y)] = n.z;
            }
        }
        
        var min = -1;
        for (var i = 0; i <= k; ++i)
        {
            if (distances.ContainsKey((t.Item1, t.Item2, i)))
            {
                if (min == -1) min = distances[(t.Item1, t.Item2, i)];
                else min = Math.Min(min, distances[(t.Item1, t.Item2, i)]);
            }
        }
        
        return min;
    }
    
    private List<(int x, int y, int z)> GetNeighbors(int[][] grid, int i, int j, int k)
    {
        var res = new List<(int x, int y, int z)>();
        
        if (i - 1 >= 0 && (grid[i - 1][j] == 0 || k - 1 >= 0)) res.Add((i - 1, j, k - grid[i - 1][j]));
        if (i + 1 < grid.Length && (grid[i + 1][j] == 0 || k - 1 >= 0)) res.Add((i + 1, j, k - grid[i + 1][j]));
        if (j - 1 >= 0 && (grid[i][j - 1] == 0 || k - 1 >= 0)) res.Add((i, j - 1, k - grid[i][j - 1]));
        if (j + 1 < grid[i].Length && (grid[i][j + 1] == 0 || k - 1 >= 0)) res.Add((i, j + 1, k - grid[i][j + 1]));

        return res;
    }
}