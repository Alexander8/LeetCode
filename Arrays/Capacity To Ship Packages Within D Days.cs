public class Solution
{
    public int ShipWithinDays(int[] weights, int D)
    {
        if (weights.Length == D) return weights.Max();
        
        var lo = 1;
        var hi = 500 * 50000;

        while (lo <= hi)
        {
            var capacity = lo + (hi - lo) / 2;

            var days = 1;
            var load = 0;
            var i = 0;

            while (i < weights.Length)
            {
                if (load > capacity)
                {
                    days = int.MaxValue;
                    break;
                }
                
                if (load + weights[i] <= capacity)
                {
                    load += weights[i];
                    ++i;
                }
                else
                {
                    load = weights[i];
                    ++days;
                    ++i;
                }
            }

            if (days <= D)
                hi = capacity- 1;
            else
                lo = capacity + 1;
        }

        return lo;
    }
}