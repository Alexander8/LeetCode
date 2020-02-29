public class Solution 
{
    public int[] FindRightInterval(int[][] intervals) 
    {
        var map = intervals
            .Select((x, i) => (start: x[0], index: i))
            .ToDictionary(x => x.start, x => x.index);
        
        var ordered = intervals.Select(x => x[0]).OrderBy(x => x).ToList();
        
        var res = new int[intervals.Length];
        
        for (var i = 0; i < intervals.Length; ++i)
        {
            var pos = ordered.BinarySearch(intervals[i][1]);
            if (pos >= 0)
            {
                res[i] = map[ordered[pos]];
            }
            else
            {
                pos = ~pos;
                res[i] = pos == ordered.Count ? -1 : map[ordered[pos]];
            }
        }
            
        return res;
    }
}