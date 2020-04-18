public class Solution 
{
    public int MaximalSquare(char[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;

        var max = 0;
        var dp = new int[matrix.Length, matrix[0].Length];

        for (var i = 0; i < matrix.Length; ++i)
        {
            for (var j = 0; j < matrix[i].Length; ++j)
            {
                if (matrix[i][j] == '0') continue;

                var topLeft = i - 1 >= 0 && j - 1 >= 0 ? dp[i - 1, j - 1] : 0;
                var top = i - 1 >= 0 ? dp[i - 1, j] : 0;
                var left = j - 1 >= 0 ? dp[i, j - 1] : 0;

                dp[i, j] = 1 + Math.Min(topLeft, Math.Min(top, left));

                max = Math.Max(max, dp[i, j]);
            }
        }

        return max * max;
    }
}