public class Solution 
{
    public int OrangesRotting(int[][] grid) 
    {
        var q = new Queue<(int, int, int)>();
        var fresh = new Dictionary<(int, int), int>(); 
         
        for (var i = 0; i < grid.Length; ++i)
        {
            for (var j = 0; j < grid[i].Length; ++j)
            {
                if (grid[i][j] == 1)
                    fresh.Add((i, j), -1);
                else if (grid[i][j] == 2)
                    q.Enqueue((i, j, 0));
            }
        }
        
        if (fresh.Count == 0) return 0;
        
        BFS(grid, q, fresh);        
        
        var time = fresh.Values.Max();
        return fresh.Values.All(x => x != -1) ? time : - 1;
    }
    
    private static void BFS(int[][] grid, 
        Queue<(int i, int j, int time)> q, 
        Dictionary<(int, int), int> fresh)
    {            
        while (q.Count > 0)
        {
            var p = q.Dequeue();
            
            var neighbors = GetNeighbors(grid, p.i, p.j);
            
            foreach (var n in neighbors)
            {
                var newTime = p.time + 1;
                var currTime = fresh[(n.i, n.j)];
                
                if (currTime == -1 || currTime > newTime)
                {
                    q.Enqueue((n.i, n.j, newTime));
                    fresh[(n.i, n.j)] = newTime;
                }
            }
        }
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

// #2
public class Solution 
{
    public int OrangesRotting(int[][] grid) 
    {
        var time = 0;
        
        while (true)
        {
            var q = new Queue<(int r, int c)>();
            var fresh = new HashSet<(int, int)>();

            for (var i = 0; i < grid.Length; ++i)
            {
                for (var j = 0; j < grid[i].Length; ++j)
                {
                    if (grid[i][j] == 1)
                        fresh.Add((i, j));
                    else if (grid[i][j] == 2)
                        q.Enqueue((i, j));
                }
            }

            if (fresh.Count == 0)
                break;
            
            var initialCount = fresh.Count;

            while (q.Count > 0)
            {
                var o = q.Dequeue();

                foreach (var dir in _dirs)
                {
                    var r = o.r + dir[0];
                    var c = o.c + dir[1];

                    if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length)
                        continue;

                    if (grid[r][c] == 1)
                    {
                        grid[r][c] = 2;
                        fresh.Remove((r, c));
                    }
                }
            }
            
            ++time;
            
            if (fresh.Count == 0)
                break;
            
            if (fresh.Count == initialCount)
                return -1;
        }
        
        return time;
    }
    
    private static readonly int[][] _dirs = new int[][]
    {
        new int[] {0,1},
        new int[] {-1, 0},
        new int[] {1,0},
        new int[] {0, -1}
    };
}
