public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) 
    {
        var lst = new List<int[]>(intervals.Length + 1);
        lst.AddRange(intervals);
        
        var i = 0;
        var inserted = false;
        
        while (i < lst.Count)
        {
            if ((i == 0 || lst[i - 1][1] < newInterval[0]) && newInterval[1] < lst[i][0])
            {
                lst.Insert(i, newInterval);
                inserted = true;
                break;
            }
            
            if (newInterval[0] <= lst[i][1] || newInterval[1] >= lst[i][0] && newInterval[1] < lst[i][1])
            {
                var left = Math.Min(newInterval[0], lst[i][0]);
                var right = Math.Max(newInterval[1], lst[i][1]);
                
                lst.RemoveAt(i);
                
                lst.Insert(i, new [] { left, right });

                inserted = true;
                
                break;
            }
            
            ++i;
        }
        
        if (!inserted)
        {
            lst.Add(newInterval);
            return lst.ToArray();
        }
        
        while (i < lst.Count)
        {                
            if (i < lst.Count - 1 && lst[i][1] < lst[i + 1][0])
            {
                break;
            }
            
            if (i < lst.Count - 1 && lst[i][1] >= lst[i + 1][0])
            {
                lst[i][1] = Math.Max(lst[i][1], lst[i + 1][1]);
                lst.RemoveAt(i + 1);
                continue;
            }
            
            ++i;
        }
        
        return lst.ToArray();
    }
}