public class Solution 
{
    public int MaxUncrossedLines(int[] A, int[] B) 
    {
        var dp = new int[A.Length, B.Length];
        
        for (var i = 0; i < A.Length; ++i)
        {
            for (var j = 0; j < B.Length; ++j)
            {
                var soFar = Math.Max(i > 0 ? dp[i - 1, j] : 0, j > 0 ? dp[i, j - 1] : 0);
                var current = A[i] == B[j] 
                    ? 1 + (i > 0 && j > 0 ? dp[i - 1, j - 1] : 0) 
                    : 0;
                dp[i, j] = Math.Max(current, soFar);
            }
        }
        
        return dp[A.Length - 1, B.Length - 1];
    }
}