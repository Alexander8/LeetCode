public class Solution 
{
    public int LongestSubarray(int[] nums, int limit) 
    {
        var res = 1;
        
        for (var i = 0; i < nums.Length; ++i)
        {
            var len = 1;
            var min = nums[i];
            var max = nums[i];
            
            if (res < nums.Length - i)
            {            
                for (var j = i + 1; j < nums.Length; ++j)
                {
                    if (Math.Abs(nums[j] - min) > limit || Math.Abs(nums[j] - max) > limit)
                        break;

                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);

                    ++len;

                    res = Math.Max(res, len);
                }
            }
        }
        
        return res;
    }
}