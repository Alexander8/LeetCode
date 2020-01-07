public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {       
        var cnt = 0;
        var prefixSums = new int[nums.Length + 1];
        
        for (var i = 1; i <= nums.Length; ++i)
            prefixSums[i] = prefixSums[i - 1] + nums[i - 1];

        for (var i = 0; i < nums.Length; ++i)
        {
            for (var j = i + 1; j <= nums.Length; ++j)
            {
                if (prefixSums[j] - prefixSums[i] == k)
                    ++cnt;
            }
        }
        
        return cnt;
    }
}

public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {       
        var cnt = 0;

        for (var i = 0; i < nums.Length; ++i)
        {
            var sum = 0;
            
            for (var j = i; j < nums.Length; ++j)
            {
                sum += nums[j];
                
                if (sum == k)
                    ++cnt;
            }
        }
        
        return cnt;
    }
}

public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {       
        var cnt = 0;
        var sum = 0;
        var map = new Dictionary<int, int> { { 0, 1} };

        for (var i = 0; i < nums.Length; ++i)
        {
            sum += nums[i];
            if (map.ContainsKey(sum - k))
                cnt += map[sum - k];
            
            if (map.ContainsKey(sum))
                map[sum] += 1;
            else
                map[sum] = 1;
        }
        
        return cnt;
    }
}