public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        var dp = new int[nums.Length, 2];
        var longest = int.MinValue;

        for (var i = 0; i < nums.Length; ++i)
        {
            dp[i, 0] = 1;
            dp[i, 1] = 1;

            for (var j = i - 1; j >= 0; --j)
            {
                if (nums[i] > nums[j])
                {
                    if (dp[j, 0] + 1 > dp[i, 0])
                    {
                        dp[i, 0] = dp[j, 0] + 1;
                        dp[i, 1] = dp[j, 1];
                    }
                    else if (dp[j, 0] + 1 == dp[i, 0])
                    {
                        dp[i, 1] += dp[j, 1];
                    }
                }
            }

            longest = Math.Max(longest, dp[i, 0]);
        }

        var cnt = 0;
        for (var i = 0; i < nums.Length; ++i)
        {
            if (dp[i, 0] == longest)
                cnt += dp[i, 1];
        }

        return cnt;
    }
}