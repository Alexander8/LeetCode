public class Solution 
{
    public int HammingDistance(int x, int y) 
    {
        var xor = x ^ y;
        var cnt = 0;
        
        while (xor != 0)
        {
            cnt += (xor & 1);
            xor >>= 1;
        }
        
        return cnt;
    }
}