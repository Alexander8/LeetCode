public class Solution 
{
    public int ProjectionArea(int[][] grid) 
    {
        var xy = 0;        
        var xz = 0;
        var yz = 0;
        
        for (var x = 0; x < grid.Length; ++x)
        {
            var max = 0;
            
            for (var y = 0; y < grid[x].Length; ++y)
            {
                max = Math.Max(grid[x][y], max);
                
                if (grid[x][y] != 0) ++xy;
            }
                
            xz += max;
        }
        
        for (var y = 0; y < grid[0].Length; ++y)
        {
            var max = 0;
            
            for (var x = 0; x < grid.Length; ++x)
            {
                max = Math.Max(grid[x][y], max);
            }
                
            yz += max;
        }
        
        return xy + xz + yz;
    }
}