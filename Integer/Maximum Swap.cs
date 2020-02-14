public class Solution 
{
    public int MaximumSwap(int num) 
    {
        if (num <= 9) return num;
        
        var nums = new List<int>();
        
        while (num != 0)
        {
            var d = num % 10;
            nums.Insert(0, d);
            num /= 10;
        }
        
        for (var i = 0; i < nums.Count - 1; ++i)
        {
            var candidate = nums[i];
            var max = nums.Skip(i + 1).Max();

            if (max > candidate)
            {
                var maxIdx = nums.LastIndexOf(max);
                nums[i] = max;
                nums[maxIdx] = candidate;
                break;
            }
        }
        
        var res = 0;
        
        for (var i = 0; i < nums.Count; ++i)
        {
            res *= 10;
            res += nums[i];
        }
        
        return res;
    }
}