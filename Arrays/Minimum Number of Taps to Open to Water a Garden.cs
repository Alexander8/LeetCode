public class Solution 
{
    public int MinTaps(int n, int[] ranges)
    {
        var cnt = 1;
        var intervals = new (int x, int y)[n + 1];

        for (var i = 0; i < n + 1; ++i)
            intervals[i] = (Math.Max(0, i - ranges[i]), Math.Min(n, i + ranges[i]));

        intervals = intervals.OrderBy(i => i.x).ThenByDescending(i => i.y - i.x).ToArray();

        var prev = intervals[0];
        var merged = new List<(int x, int y)>();

        for (var i = 1; i < intervals.Length; ++i)
        {
            var curr = intervals[i];

            if (prev.y < curr.x) return -1;

            if (curr.x >= prev.x && curr.y <= prev.y) continue;

            merged.Add(prev);
            prev = curr;
        }

        merged.Add(prev);

        var j = 1;
        while (j < merged.Count - 1)
        {
            if (merged[j - 1].y >= merged[j + 1].x)
                merged.RemoveAt(j);
            else
                ++j;
        }

        return merged.Count;
    }
}