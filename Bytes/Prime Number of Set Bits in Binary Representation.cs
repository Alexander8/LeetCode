public class Solution 
{
    public int CountPrimeSetBits(int L, int R) 
    {
        var cnt = 0;
        
        for (var i = L; i <= R; ++i)
        {
            var tmp = i;
            var cntTmp = 0;
            while (tmp != 0) 
            {
                if ((tmp & 1) == 1)
                    ++cntTmp;
                
                tmp >>= 1;               
            }
            
            if (IsPrime(cntTmp)) ++cnt;
        }
        
        return cnt;
    }
    
    private static bool IsPrime(int n)
    {
        if (n == 1) return false;
        
        for (var i = 2; i <= Math.Sqrt(n); ++i)
            if (n % i == 0) return false;
        
        return true;
    }
}