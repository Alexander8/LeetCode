public class Solution 
{
    public int NumOfSubarrays(int[] arr, int k, int threshold) 
    {
        if (arr.Length < k) return 0;
        
        var sum = arr.Take(k).Sum();
        var cnt = (double)sum / k >= threshold ? 1 : 0;
        
        for (var i = k; i < arr.Length; ++i)
        {
            sum -= arr[i - k];
            sum += arr[i];
            
            if ((double)sum / k >= threshold)
                ++cnt;
        }
        
        return cnt;
    }
}