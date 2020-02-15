public class Solution 
{
    public int NumberOfArithmeticSlices(int[] A) 
    {
        if (A.Length < 3) return 0;
        
        var cnt = 0;
        var len = 2;
        var diffPrev = A[1] - A[0];
        
        for (var i = 2; i < A.Length; ++i)
        {
            var diff = A[i] - A[i - 1];
            
            if (diff != diffPrev)
            {
                if (len >= 3) 
                    cnt += Count(len);
                
                len = 2;
                diffPrev = diff;                
            }
            else
            {
                ++len;
                
                if (i == A.Length - 1)
                    cnt += Count(len);
            }
        }
        
        return cnt;
    }
    
    private static int Count(int len)
    {
        return (len * len - 3 * len + 2) / 2;
    }
}