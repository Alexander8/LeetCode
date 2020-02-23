public class Solution 
{
    public int FirstMissingPositive(int[] nums) 
    {
        var set = new HashSet<int>();
        var min = 1;
        var max = 1;
        
        foreach (var num in nums)
        {
            if (num >= 0)
            {
                set.Add(num);           
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }
        }
        
        for (var i = min; i <= max; ++i)
        {
            if (!set.Contains(i)) return i;
        }
        
        return max + 1;
    }
}