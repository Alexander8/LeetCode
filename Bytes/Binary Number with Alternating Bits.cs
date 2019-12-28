public class Solution 
{
    public bool HasAlternatingBits(int n) 
    {
        var next = -1;

        while (n != 0)
        {
            var test = n & 1;

            if (next == 0 && test == 1) return false;
            if (next == 1 && test == 0) return false;

            next = ~test & 1;

            n >>= 1;
        }

        return true;
    }
}