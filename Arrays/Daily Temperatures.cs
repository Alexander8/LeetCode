public class Solution 
{
    public int[] DailyTemperatures(int[] T) 
    {
        var TT = new int[T.Length];
        var map = new Dictionary<int, int>();
        
        for (var i = T.Length - 1; i >= 0; --i)
        {
            var day = int.MaxValue;
            
            for (var t = T[i] + 1; t <= 100; ++t)
            {
                if (map.TryGetValue(t, out var idx) && idx - i < day)
                {
                    day = idx - i;
                }
            }
            
            map[T[i]] = i;
            
            TT[i] = day != int.MaxValue ? day : 0;
        }
        
        return TT;
    }
}