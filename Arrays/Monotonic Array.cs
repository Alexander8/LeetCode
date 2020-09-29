public class Solution 
{
    public bool IsMonotonic(int[] A) 
    {
        var incr = true;
        var decr = true;
        
        for (var i = 1; i < A.Length; ++i)
        {
            if (A[i - 1] == A[i]) continue;  
            
            if (A[i - 1] < A[i]) decr = false;            
            if (A[i - 1] > A[i]) incr = false;
            
            if (!incr && !decr) break;
        }
        
        return incr || decr;
    }
}