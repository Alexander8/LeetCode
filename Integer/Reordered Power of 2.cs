public class Solution 
{
    public bool ReorderedPowerOf2(int N) 
    {
        var len = GetLength(N);
        
        var powerOf2s = new List<int>();
                
        for (var i = 1; ; i *= 2)
        {
            var lenTmp = GetLength(i);
            
            if (lenTmp < len) continue;
            
            if (lenTmp > len) break;
            
            powerOf2s.Add(i);
        }
        
        foreach (var powerOf2 in powerOf2s)
            if (CanReorder(N, powerOf2)) return true;
        
        return false;
    }
    
    private static int GetLength(int n)
    {
        var len = 0;
        
        while (n != 0)
        {
            n /= 10;
            ++len;
        }
        
        return len;
    }
    
    private static bool CanReorder(int a, int b)
    {
        var d1 = GetDigits(a);
        var d2 = GetDigits(b);
        
        return d1.SequenceEqual(d2);
    }
    
    private static IEnumerable<int> GetDigits(int n)
    {
        var res = new List<int>(9);
        
        while (n != 0)
        {
            res.Add(n % 10);
            n /= 10;
        }
        
        return res.OrderBy(d => d);
    }
}