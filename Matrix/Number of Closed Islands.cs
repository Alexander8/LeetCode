public class Solution 
{
    private static readonly int[][] Directions = new[] 
    { 
        new[] { -1, 0 },
        new[] { 1, 0 },
        new[] { 0, -1 },
        new[] { 0, 1 }
    };
    
    public int ClosedIsland(int[][] grid) 
    {
        var cnt = 0;
        var visited = new HashSet<(int, int)>();
        
        for (var i = 0; i < grid.Length; ++i)
        {
            for (var j = 0; j < grid[i].Length; ++j)
            {
                if (grid[i][j] == 0 && !visited.Contains((i, j)))
                {
                    if (IsClosedIsland(grid, visited, i, j))
                        ++cnt;
                }
            }
        }
        
        return cnt;
    }
    
    private static bool IsClosedIsland(int[][] grid, HashSet<(int, int)> visited, int i, int j)
    {
        var result = true;
        var q = new Queue<(int r, int c)>();
        q.Enqueue((i, j));
        visited.Add((i, j));

        while (q.Count > 0)
        {
            var p = q.Dequeue();

            foreach (var dir in Directions)
            {                
                var r = p.r + dir[0];
                var c = p.c + dir[1];

                if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length)
                {
                    result = false;
                    continue;
                }

                if (grid[r][c] == 1) continue;

                if (visited.Add((r, c)))
                    q.Enqueue((r, c));
            }
        }

        return result;
    }
}