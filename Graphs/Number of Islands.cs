public class Solution 
{
    public int NumIslands(char[][] grid) 
    {
        var cnt = 0;
        
        var visited = new HashSet<Tuple<int, int>>();
        
        for (var i = 0; i < grid.Length; ++i)
        {
            for (var j = 0; j < grid[i].Length; ++j)
            {
                if (grid[i][j] == '0')
                {
                    continue;
                }
                
                var point = Tuple.Create(i, j);
                if (visited.Contains(point))
                {
                    continue;
                }
                
                ++cnt;
                
                ExploreIsland(point, grid, visited);
            }
        }
        
        return cnt;
    }
    
    private static void ExploreIsland(Tuple<int, int> point, char[][] grid, HashSet<Tuple<int, int>> visited)
    {
        var queue = new Queue<Tuple<int, int>>();
        
        queue.Enqueue(point);
        visited.Add(point);
        
        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            
            foreach (var n in GetNeighbors(p, grid))
            {
                if (visited.Contains(n))
                {
                    continue;
                }
                
                queue.Enqueue(n);
                visited.Add(n);
            }
        }
    }
    
    private static List<Tuple<int, int>> GetNeighbors(Tuple<int, int> point, char[][] grid)
    {
        var res = new List<Tuple<int, int>>();
        var i = point.Item1;
        var j = point.Item2;
        
        if (i - 1 >= 0 && grid[i-1][j] == '1')
        {
            res.Add(Tuple.Create(i - 1, j));
        }
        
        if (i + 1 < grid.Length && grid[i+1][j] == '1')
        {
            res.Add(Tuple.Create(i + 1, j));
        }
        
        if (j - 1 >= 0 && grid[i][j-1] == '1')
        {
            res.Add(Tuple.Create(i, j - 1));
        }
        
        if (j + 1 < grid[i].Length && grid[i][j+1] == '1')
        {
            res.Add(Tuple.Create(i, j + 1));
        }
        
        return res;
    }
}