class Solution 
{
    public int arrangeCoins(int n) 
    {        
        var lo = 0;
        var hi = 65535;
        
        while (lo <= hi)
        {
            var m = lo + (hi - lo) / 2;
            
            double sum = (1 + m) / 2d * m;
            
            if (sum == (double)n)
                return m;
            
            if (sum < (double)n)
                lo = m + 1;
            else
                hi = m - 1;
        }
        
        return lo - 1;
    }
}