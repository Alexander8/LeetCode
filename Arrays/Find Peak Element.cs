public class Solution 
{
    public int FindPeakElement(int[] nums) 
    {
        var q = new Queue<(int lo, int hi)>();
        q.Enqueue((0, nums.Length - 1));
        
        while (q.Count > 0)
        {
            var p = q.Dequeue();
            
            var m = p.lo + (p.hi - p.lo) / 2;
            
            var left = m - 1 < 0 || nums[m - 1] < nums[m];
            var right = m + 1 > nums.Length - 1 || nums[m + 1] < nums[m];
            
            if (left && right)
                return m;
            
            var lo1 = p.lo;
            var hi1 = m - 1;
            
            if (lo1 <= hi1)
                q.Enqueue((lo1, hi1));
            
            var lo2 = m + 1;
            var hi2 = p.hi;
            
            if (lo2 <= hi2)
                q.Enqueue((lo2, hi2));
        }   
        
        return -1;
    }
}