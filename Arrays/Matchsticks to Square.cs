public class Solution 
{
    public bool Makesquare(int[] nums) 
    {
        if (nums.Length < 4) return false;
        
        var sum = nums.Sum();
        var side = sum / 4;
        
        if (side * 4 != sum) return false;
        
        Array.Sort(nums);
        Array.Reverse(nums);
                
        return Makesquare(nums, 0, new int[4], side);
    }
    
    private static bool Makesquare(int[] nums, int idx, int[] sums, int side)
    {
        if (idx == nums.Length)
            return sums[0] == sums[1] && sums[1] == sums[2] && sums[2] == sums[3];
        
        for (var i = 0; i < 4; ++i)
        {
            if (sums[i] + nums[idx] <= side)
            {
                sums[i] += nums[idx];
                if (Makesquare(nums, idx + 1, sums, side))
                    return true;
                
                sums[i] -= nums[idx];
            }
        }
        
        return false;
    }
}