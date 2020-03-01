public class Solution 
{
    public int MinCost(int[][] grid) 
    {
        var q = new Queue<(int i, int j, int cost)>();
        var visited = new Dictionary<(int, int), int>();
        var cost = int.MaxValue;
        
        q.Enqueue((0,0,0));
        visited[(0,0)] = 0;
        
        while (q.Count > 0)        
        {
            var p = q.Dequeue();
            
            if (p.i == grid.Length - 1 && p.j == grid[grid.Length - 1].Length - 1)
            {
                cost = Math.Min(cost, p.cost);
                continue;
            }
            
            var neighbors = GetNeighbors(grid, p.i, p.j);
            
            foreach (var n in neighbors)
            {
                var newCost = p.cost + n.cost;
                
                if (!visited.TryGetValue((n.i, n.j), out var currCost) || currCost > newCost)
                {
                    visited[(n.i, n.j)] = newCost;
                    q.Enqueue((n.i, n.j, newCost));
                }
            }
        }
        
        return cost;
    }
    
    private static List<(int i, int j, int cost)> GetNeighbors(int[][] grid, int i, int j)
    {
        var res = new List<(int i, int j, int cost)>();
        
        if (j + 1 < grid[i].Length)
            res.Add((i, j + 1, grid[i][j] == 1 ? 0 : 1));

        if (i + 1 < grid.Length)
            res.Add((i + 1, j, grid[i][j] == 3 ? 0 : 1));

        if (j - 1 >= 0)
            res.Add((i, j - 1, grid[i][j] == 2 ? 0 : 1));

        if (i - 1 >= 0)
            res.Add((i - 1, j, grid[i][j] == 4 ? 0 : 1));        
        
        return res;
    }
}