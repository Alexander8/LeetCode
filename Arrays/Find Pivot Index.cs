public class Solution 
{
    public int PivotIndex(int[] nums) 
    {
        var forward = new int[nums.Length];
        var backward = new int[nums.Length];
        
        for (var i = 0; i < nums.Length; ++i)
        {
            forward[i] = (i - 1 >= 0 ? forward[i - 1] : 0) + nums[i];
            backward[nums.Length - 1 - i] = 
                (nums.Length - i < nums.Length ? backward[nums.Length - i] : 0) + nums[nums.Length - 1 - i];
        }
        
        for (var i = 0; i < nums.Length; ++i)
        {
            if (forward[i] == backward[i])
                return i;
        }
        
        return -1;
    }
}