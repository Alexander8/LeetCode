public class Solution 
{
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        var res = new List<int>();
        var maxDeque = new LinkedList<int>();
        var start = 0;
        var stop = 0;
        
        while (start < nums.Length - k + 1)
        {
            while (stop - start < k)
            {
                while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[stop]) maxDeque.RemoveLast();

                maxDeque.AddLast(stop);
                
                ++stop;
            }
            
            var max = nums[maxDeque.First.Value];
            res.Add(max);
            
            ++start;
            
            if (maxDeque.First.Value < start) 
                maxDeque.RemoveFirst();
        }
        
        return res.ToArray();
    }
}