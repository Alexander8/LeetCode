public class Solution 
{
    public int ArrangeCoins(int n) 
    {
        var res = 0.5 * (-1 + Math.Sqrt(1 + 8 * (double)n));
        return (int)res;
    }
}