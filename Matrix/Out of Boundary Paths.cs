public class Solution 
{
    public int FindPaths(int m, int n, int N, int i, int j) 
    {
        var cnt = 0;
        var M = 1000000000 + 7;
        var dp = new int[m, n];
        dp[i, j] = 1;
        
        for (var move = 0; move < N; ++move)
        {
            var temp = new int[m, n];
            
            for (var r = 0; r < m; ++r)
            {
                for (var c = 0; c < n; ++c)
                {
                    if (r == 0) cnt = (cnt + dp[r, c]) % M;
                    if (c == 0) cnt = (cnt + dp[r, c]) % M;
                    if (r == m - 1) cnt = (cnt + dp[r, c]) % M;
                    if (c == n - 1) cnt = (cnt + dp[r, c]) % M;
                    
                    temp[r, c] = 
                    (
                        ((r > 0 ? dp[r - 1, c] : 0) + (r < m - 1 ? dp[r + 1, c] : 0)) % M
                        +
                        ((c > 0 ? dp[r, c - 1] : 0) + (c < n - 1 ? dp[r, c + 1] : 0)) % M
                    ) % M;
                }
            }
            
            dp = temp;
        }
        
        return cnt;
    }
}