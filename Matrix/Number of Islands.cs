public class Solution 
{
    public int NumIslands(char[][] grid) 
    {
        var cnt = 0;
        var visited = new HashSet<(int, int)>();
        
        for (var i = 0; i < grid.Length; ++i)
        {
            for (var j = 0; j < grid[i].Length; ++j)
            {
                if (grid[i][j] == '1' && !visited.Contains((i, j)))
                {
                    ++cnt;
                    Explore(grid, i, j, visited);
                }
            }
        }
        
        return cnt;
    }
    
    private static readonly int[][] _dirs = new int[][]
    {
        new int[] {0,1},
        new int[] {-1, 0},
        new int[] {1,0},
        new int[] {0, -1}
    };
    
    private static void Explore(char[][] grid, int r, int c, HashSet<(int, int)> visited)
    {
        var q = new Queue<(int r, int c)>();
        
        q.Enqueue((r, c));
        visited.Add((r, c));
        
        while (q.Count > 0)
        {
            var x = q.Dequeue();
            
            foreach (var dir in _dirs)
            {
                r = x.r + dir[0];
                c = x.c + dir[1];
                
                if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length)
                    continue;
                
                if (grid[r][c] == '0')
                    continue;
                
                if (visited.Add((r, c)))
                    q.Enqueue((r, c));
            }
        }
    }
}