public class Solution 
{    
    public int NumSquares(int n) 
    {
        var dp = new int[Math.Max(n, 3) + 1];
        Array.Fill(dp, int.MaxValue);
        
        dp[0] = 0;       
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 3;
        
        for (var i = 4; i <= n; ++i)
        {
            for (var j = 1; j * j <= i; ++j)
            {
                dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
            }
        }
        
        return dp[n];
    }
}