public class Solution 
{
    public int MinFlips(int a, int b, int c) 
    {
        var cnt = 0;
        var tmp = a | b;
        
        if (tmp == c) return cnt;
        
        while (a != 0 || b != 0 || c != 0)
        {
            var endA = a & 1;
            var endB = b & 1;
            var endC = c & 1;
            
            if ((endA | endB) != endC)
                cnt += endA == 1 && endB == 1 ? 2 : 1;
            
            a >>= 1;
            b >>= 1;
            c >>= 1;
        }
        
        return cnt;
    }
}