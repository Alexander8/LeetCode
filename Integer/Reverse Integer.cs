public class Solution 
{
    public int Reverse(int x) 
    {
        var tmp = Math.Abs((long)x);
        long reversed = 0;
        
        while (tmp != 0)
        {
            reversed = reversed * 10L + (tmp % 10);
            tmp /= 10;
        }
        
        if (x < 0) reversed *= -1;
        
        if (reversed < int.MinValue || reversed > int.MaxValue) return 0;
        
        return (int)reversed;
    }
}