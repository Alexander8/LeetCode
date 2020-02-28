public class Solution 
{
    public int MaxAreaOfIsland(int[][] grid) 
    {
        var area = 0;
        var visited = new HashSet<(int, int)>();
        
        for (var i = 0; i < grid.Length; ++i)
            for (var j = 0; j < grid[i].Length; ++j)
                if (grid[i][j] == 1 && !visited.Contains((i, j)))
                    area = Math.Max(area, GetArea(grid, i, j, visited));
                    
        return area;
    }
    
    private static int GetArea(int[][] grid, int i, int j, HashSet<(int, int)> visited)
    {
        var q = new Queue<(int i, int j)>();
        var area = 0;
        
        q.Enqueue((i, j));
        visited.Add((i, j));        
        
        while (q.Count > 0)
        {
            var p = q.Dequeue();
            ++area;
            
            var neighbors = GetNeighbors(grid, p.i, p.j);
            foreach (var n in neighbors)
                if (visited.Add((n.i, n.j)))
                    q.Enqueue((n.i, n.j));
        }
        
        return area;
    }

    private static List<(int i, int j)> GetNeighbors(int[][] grid, int i, int j)
    {
        var res = new List<(int i, int j)>();
        
        if (i - 1 >= 0 && grid[i - 1][j] == 1)
            res.Add((i - 1, j));
        
        if (i + 1 < grid.Length && grid[i + 1][j] == 1)
            res.Add((i + 1, j));
        
        if (j - 1 >= 0 && grid[i][j - 1] == 1)
            res.Add((i, j - 1));
        
        if (j + 1 < grid[i].Length && grid[i][j + 1] == 1)
            res.Add((i, j + 1));
        
        return res;
    }
}