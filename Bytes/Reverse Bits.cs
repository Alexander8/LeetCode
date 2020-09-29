public class Solution 
{
    public uint reverseBits(uint n) 
    {
        uint reversed = 0;
        
        for (var i = 0; i < 32; ++i)
        {
            if (i > 0) reversed <<= 1;

            var last = n & 1;
            n >>= 1;

            reversed |= last;
        }

        return reversed;
    }
}