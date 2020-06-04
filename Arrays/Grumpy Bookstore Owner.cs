public class Solution
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int X)
    {
        int sum = 0, maxSum = 0;
        int start = 0, stop = 0;
        int startX = 0;

        while (stop < customers.Length)
        {
           sum += grumpy[stop] == 1 ? customers[stop] : 0;

            while (start <= stop && (stop - start + 1 > X || grumpy[start] == 0))
            {
                sum -= grumpy[start] == 1 ? customers[start] : 0;
                ++start;
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                startX = start;
            }

            ++stop;
        }

        sum = 0;
        var i = 0;

        while (i < customers.Length)
        {
            if (i == startX)
            {
                for (; i < startX + X && i < customers.Length; ++i)
                    sum += customers[i];
            }
            else
            {
                if (grumpy[i] == 0)
                    sum += customers[i];
                ++i;
            }
        }

        return sum;
    }
}