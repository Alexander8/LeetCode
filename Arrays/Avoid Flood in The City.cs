public class Solution 
{
    public int[] AvoidFlood(int[] rains) 
    {
        var lakeMap = new Dictionary<int, int>();
        var dayMap = new Dictionary<int, int>();
        var dryDays = new List<int>();

        for (var i = 0; i < rains.Length; ++i)
        {
            if (rains[i] == 0)
            {
                dryDays.Add(i);
                continue;
            }

            if (lakeMap.TryGetValue(rains[i], out var day))
            {
                if (dryDays.Count == 0) return new int[0];

                var idx = dryDays.BinarySearch(day);
                if (idx < 0) idx = ~idx;

                if (idx == dryDays.Count) return new int[0];

                lakeMap[rains[i]] = i;
                dayMap.Add(dryDays[idx], rains[i]);
                dryDays.RemoveAt(idx);
            }
            else
            {
                lakeMap.Add(rains[i], i);
                dayMap.Add(i, -1);
            }
        }

        var res = new int[rains.Length];
        for (var i = 0; i < rains.Length; ++i)
        {
            if (dayMap.TryGetValue(i, out var lake))
                res[i] = lake;
            else
                res[i] = rains[i] > 0 ? -1 : 1;
        }

        return res;
    }
}
