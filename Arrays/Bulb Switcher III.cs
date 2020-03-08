public class Solution 
{
    public int NumTimesAllBlue(int[] light) 
    {
        var missing = new HashSet<int>();
        var store = new HashSet<int>();
        var count = 0;
        
        for (var i = 0; i < light.Length; ++i) 
        {
            if (!store.Contains(i + 1) && i + 1 != light[i])
                missing.Add(i + 1);
            
            if (i + 1 < light[i])
                store.Add(light[i]);
            else
                missing.Remove(light[i]);
            
            if (missing.Count == 0)
                count++;
        }
        
        return count;
    }
}