public class Solution 
{
    public int NumOfWays(int n) 
    {        
        if (n == 1) return 12;
        
        var i = 1;   
        ulong d = 6;
        ulong s = 6;
        ulong mod = 1_000_000_000 + 7;

        while (i < n - 1)
        {         
            var dTmp = ((d * 3) % mod + (s * 2) % mod) % mod;
            var sTmp = ((d * 2) % mod + (s * 2) % mod) % mod;

            d = dTmp;
            s = sTmp;

            ++i;
        }
        
        ulong cnt = (((d * (3 + 2)) % mod) + ((s * (2 + 2)) % mod)) % mod;
        return (int)cnt;
    }
}