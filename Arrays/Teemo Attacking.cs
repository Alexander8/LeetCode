public class Solution 
{
    public int FindPoisonedDuration(int[] timeSeries, int duration) 
    {
        if (timeSeries.Length == 0) return 0;
        
        var total = duration;
        var end = timeSeries[0] + duration;
        
        for (var i = 1; i < timeSeries.Length; ++i)
        {            
            if (end <= timeSeries[i])
            {
                total += duration;
                end = timeSeries[i] + duration;           
            }
            else
            {
                total += timeSeries[i] + duration - end;
                end = timeSeries[i] + duration; 
            }
        }
        
        return total;
    }
}