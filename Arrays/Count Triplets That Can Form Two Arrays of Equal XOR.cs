public class Solution 
{
    public int CountTriplets(int[] arr) 
    {
        var map = new Dictionary<int, (List<(int i, int j)> intervals, Dictionary<int, int> counts)>();

        for (var i = 0; i < arr.Length; ++i)
        {
            var xor = arr[i];

            for (var j = i; j < arr.Length; ++j)
            {
                if (j > i)
                    xor ^= arr[j];

                if (!map.TryGetValue(xor, out var data))
                {
                    data = (new List<(int i, int j)>(), new Dictionary<int, int>());
                    map.Add(xor, data);
                }

                data.intervals.Add((i, j));

                data.counts.TryGetValue(i, out var tmp);
                data.counts[i] = tmp + 1;
            }
        }

        var cnt = 0;

        foreach (var item in map)
        {
            var data = item.Value;
            for (var i = 0; i < data.intervals.Count; ++i)
            {
                var interval = data.intervals[i];

                data.counts.TryGetValue(interval.j + 1, out var tmp);

                cnt += tmp;
            }
        }

        return cnt;
    }
}