public class Solution 
{
    public int FindMaxLength(int[] nums) 
    {
        var len = 0;
        var count = 0;
        var map = new Dictionary<int, int>();
        map.Add(0, -1);
           
        for (var i = 0; i < nums.Length; ++i)
        {
            count += nums[i] == 0 ? -1 : 1;
            if (map.TryGetValue(count, out var idx))
                len = Math.Max(len, i - idx);
            else
                map.Add(count, i);
        }
        
        return len;
    }    
}