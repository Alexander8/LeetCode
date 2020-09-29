public class Solution 
{
    public int UniquePaths(int m, int n) 
    {
        var dp = new int[n, m];
        
        for (var i = 0; i < m; ++i)
            dp[0, i] = 1;
        
        for (var i = 0; i < n; ++i)
            dp[i, 0] = 1;
        
        for (var i = 1; i < n; ++i)
            for (var j = 1; j < m; ++j)
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
        
        return dp[n - 1, m - 1];
    }
}