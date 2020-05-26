public class Solution 
{
    public int FindLength(int[] A, int[] B) 
    {
        var dp = new int[A.Length, B.Length];
        var len = 0;
        
        for (var i = 0; i < A.Length; ++i)
        {
            for (var j = 0; j < B.Length; ++j)
            {
                var current = A[i] == B[j] ? 1 + (i > 0 && j > 0 ? dp[i - 1, j - 1] : 0) : 0;
                dp[i, j] = current;
                len = Math.Max(len, current);
            }
        }
        
        return len;
    }
}