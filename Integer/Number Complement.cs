public class Solution 
{
    public int FindComplement(int num) 
    {
        var mask = 0;
        var wasOne = false;
        for (var i = 31; i >= 0; --i)
        {
            if (!wasOne && (num & (1 << i)) != 0)
                wasOne = true;

            if (wasOne)
                mask |= 1 << i;
        }        

        return ~num & mask;
    }
}