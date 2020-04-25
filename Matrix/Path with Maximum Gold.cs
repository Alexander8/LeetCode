public class Solution 
{
    private static readonly int[][] _dirs = new int[4][]
    {
        new[] { 1, 0 },
        new[] { -1, 0 },
        new[] { 0, 1 },
        new[] { 0, -1 }
    };
    
    public int GetMaximumGold(int[][] grid) 
    {
        var res = 0;
        
        for (var i = 0; i < grid.Length; ++i)
            for (var j = 0; j < grid[i].Length; ++j)
                if (grid[i][j] != 0)
                    res = Math.Max(res, GetSum(grid, i, j));
        
        return res;
    }
    
    private static int GetSum(int[][] grid, int i, int j)
    {
        var sum = 0;

        var tmp = grid[i][j];
        grid[i][j] = 0;

        for (var k = 0; k < _dirs.Length; ++k)
        {
            var r = i + _dirs[k][0];
            var c = j + _dirs[k][1];

            if (r < 0 || c < 0 || r == grid.Length || c == grid[r].Length || grid[r][c] == 0)
                continue;

            sum = Math.Max(sum, GetSum(grid, r, c));
        }

        grid[i][j] = tmp;
        return grid[i][j] + sum;
    }
}