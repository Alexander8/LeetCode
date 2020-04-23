public class Solution 
{
    public int OrderOfLargestPlusSign(int N, int[][] mines) 
    {
        var cnt = 0;
        var dp = new (int l, int t, int r, int b)[N, N];
        
        for (var i = 0; i < N; ++i)
            for (var j = 0; j < N; ++j)
                dp[i, j] = (1,1,1,1);
        
        for (var i = 0; i < mines.Length; ++i)
            dp[mines[i][0], mines[i][1]] = (0,0,0,0);
        
        for (var i = 0; i < N; ++i)
        {
            for (var j = 0; j < N; ++j)
            {
                if (dp[i, j].t == 1 && i - 1 >= 0)
                    dp[i, j].t = dp[i - 1, j].t + 1;
                
                if (dp[i, j].l == 1 && j - 1 >= 0)
                    dp[i, j].l = dp[i, j - 1].l + 1;
                
                var x = N - 1 - i;
                var y = N - 1 - j;
                
                if (dp[x, y].b == 1 && x + 1 < N)
                    dp[x, y].b = dp[x + 1, y].b + 1;
                
                if (dp[x, y].r == 1 && y + 1 < N)
                    dp[x, y].r = dp[x, y + 1].r + 1;
            }
        }
        
        for (var i = 0; i < N; ++i)
            for (var j = 0; j < N; ++j)
                cnt = Math.Max(cnt, Math.Min(dp[i, j].l, Math.Min(dp[i, j].t, Math.Min(dp[i, j].r, dp[i, j].b))));
        
        return cnt;
    }
}