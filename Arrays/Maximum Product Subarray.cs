public class Solution 
{
    public int MaxProduct(int[] nums) 
    {
        if (nums.Length == 0) return 0;

        var max = nums[0];
        var dp = new int[nums.Length, 2];
        dp[0, 0] = nums[0] > 0 ? nums[0] : 0;
        dp[0, 1] = nums[0] < 0 ? nums[0] : 0;

        for (var i = 1; i < nums.Length; ++i)
        {
            if (nums[i] >= 0)
            {
                dp[i, 0] = dp[i - 1, 0] > 0 ? dp[i - 1, 0] * nums[i] : nums[i];
                dp[i, 1] = dp[i - 1, 1] * nums[i];
            }
            else
            {
                dp[i, 0] = dp[i - 1, 1] * nums[i];
                dp[i, 1] = dp[i - 1, 0] > 0 ? dp[i - 1, 0] * nums[i] : nums[i];
            }

            max = Math.Max(max, dp[i, 0]);
        }

        return max;
    }
}