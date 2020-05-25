public class Solution 
{
    public int MaxDotProduct(int[] nums1, int[] nums2) 
    {
        var dp = new int[nums1.Length, nums2.Length];
        
        for (var i = 0; i < nums1.Length; ++i)
        {
            for (var j = 0; j < nums2.Length; ++j)
            {
                var soFar = Math.Max(i > 0 ? dp[i - 1, j] : int.MinValue, j > 0 ? dp[i, j - 1] : int.MinValue);
                var current = nums1[i] * nums2[j];
                var maxCurrent = Math.Max(i > 0 && j > 0 ? dp[i - 1, j - 1] + current : int.MinValue, current);
                dp[i, j] = Math.Max(maxCurrent, soFar);
            }
        }
        
        return dp[nums1.Length - 1, nums2.Length - 1];
    }
}