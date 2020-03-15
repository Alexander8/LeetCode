public class Solution 
{
    public int LenLongestFibSubseq(int[] A) 
    {
        var length = 0;
        var dp = new Dictionary<int, int>[A.Length];

        for (var i = 0; i < A.Length; ++i)
        {
            dp[i] = new Dictionary<int, int>();

            for (var j = i - 1; j >= 0; --j)
            {
                if (dp[j].TryGetValue(A[i], out var len))
                {
                    dp[j].Remove(A[i]);
                    dp[i].Add(A[i] + A[j], len + 1);

                    length = Math.Max(length, len + 1);
                }                
                else
                {
                    dp[i].Add(A[i] + A[j], 2);
                }
            }
        }

        return length;
    }
}