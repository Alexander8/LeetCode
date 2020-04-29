public class Solution 
{
    public int IntegerBreak(int n) 
    {
        if (n > 5)
        {
            var x = n / 3;
            var y = n % 3;
            
            if (y == 1)
                return (int)Math.Pow(3, x - 1) * 4;
            else
                return y == 0 ? (int)Math.Pow(3, x) : (int)Math.Pow(3, x) * y;
        }
        else
        {
            return n == 2 ? 1 : 2 * (n - 2);
        }
    }
}