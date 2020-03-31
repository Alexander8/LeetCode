/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl 
{
    public int FirstBadVersion(int n) 
    {
        var lo = 1;
        var hi = n;
        
        while (lo <= hi)
        {
            var m = lo + (hi - lo) / 2;
         
            if (IsBadVersion(m))
                hi = m - 1; 
            else
                lo = m + 1;    
        }
        
        return lo;
    }
}