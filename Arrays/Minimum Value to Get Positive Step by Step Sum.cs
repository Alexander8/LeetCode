public class Solution 
{
    public int MinStartValue(int[] nums) 
    {
        var x = 0;
        var sum = 0;
        
        for (var i = 0; i < nums.Length; ++i)
        {
            sum += nums[i];
            if (sum + x < 1)
            {
                x += 1 - sum - x;              
            }
        }
        
        return x == 0 ? 1 : x;
    }
}