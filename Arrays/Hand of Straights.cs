public class Solution 
{
    public bool IsNStraightHand(int[] hand, int W) 
    {
        if (hand.Length % W != 0) return false;

        if (W == 1) return true;

        var sorted = new SortedDictionary<int, int>();

        for (var i = 0; i < hand.Length; ++i)
        {
            if (sorted.TryGetValue(hand[i], out var cnt))
                sorted[hand[i]] = cnt + 1;
            else
                sorted[hand[i]] = 1;
        }

        var len = 0;
        var next = 0;

        for (var i = 0; i < hand.Length; ++i)
        {
            if (len == W)
                len = 0;

            if (len == 0)
            {
                var min = sorted.Keys.First();
                var cnt = sorted[min];

                if (cnt == 1) sorted.Remove(min);
                else sorted[min] = cnt - 1;

                ++len;
                next = min + 1;
            }
            else
            {
                if (!sorted.TryGetValue(next, out var cnt))
                    return false;

                if (cnt == 1) sorted.Remove(next);
                else sorted[next] = cnt - 1;

                ++len;
                ++next;
            }
        }

        return true;
    }
}