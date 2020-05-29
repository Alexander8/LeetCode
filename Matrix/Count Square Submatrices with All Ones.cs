public class Solution 
{
    public int CountSquares(int[][] matrix) 
    {
        var cnt = 0;
        
        for (var i = 0; i < matrix.Length; ++i)
        {
            for (var j = 0; j < matrix[i].Length; ++j)
            {
                if (matrix[i][j] == 0) continue;
                
                var leftTop = i - 1 >= 0 && j - 1 >= 0 ? matrix[i - 1][j - 1] : 0;
                var left = j - 1 >= 0 ? matrix[i][j - 1] : 0;
                var top = i - 1 >= 0 ? matrix[i - 1][j] : 0;
                
                matrix[i][j] += Math.Min(leftTop, Math.Min(left, top));
                cnt += matrix[i][j];
            }
        }
        
        return cnt;
    }
}