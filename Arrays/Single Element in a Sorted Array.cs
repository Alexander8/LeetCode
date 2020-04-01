public class Solution 
{
    public int SingleNonDuplicate(int[] nums) 
    {
        return SingleNonDuplicate(nums, 0, nums.Length - 1);
    }
    
    private static int SingleNonDuplicate(int[] nums, int lo, int hi)
    {        
        var m = lo + (hi - lo) / 2;
        
        var hasLeft = m - 1 >= 0 && nums[m - 1] == nums[m];
        var hasRight = m + 1 < nums.Length && nums[m + 1] == nums[m];
        
        if (!hasLeft && !hasRight)
            return nums[m];
        
        if (hasLeft && (m - 1 - lo) % 2 != 0 || hasRight && (m - lo) % 2 != 0)
            return SingleNonDuplicate(nums, lo, hasLeft ? m - 2 : m - 1);
        
        return SingleNonDuplicate(nums, hasLeft ? m + 1 : m + 2, hi);
    }
}