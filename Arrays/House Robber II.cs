public class Solution 
{
    public int Rob(int[] nums) 
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
        
        var opt1 = RobInternal(nums.Skip(1).ToArray());
        var opt2 = RobInternal(nums.Take(nums.Length - 1).ToArray());
        
        return Math.Max(opt1, opt2);
    }    
    
    private static int RobInternal(int[] nums) 
    {
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
        
        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = nums[1];
        
        for (var i = 2; i < nums.Length; ++i)
        {           
            var opt1 = dp[i - 2] + nums[i];
            var opt2 = dp[i - 1];
            var opt3 = i - 3 >= 0 ? dp[i - 3] + nums[i] : 0;
                     
            dp[i] = Math.Max(opt1, Math.Max(opt2, opt3));
        }
        
        return dp[dp.Length - 1];
    }
}