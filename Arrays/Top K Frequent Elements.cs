public class Solution 
{
    public int[] TopKFrequent(int[] nums, int k) 
    {
        if (k == 0) return new int[0];
        
        var res = new List<int>(k);
        var intToF = new Dictionary<int, int>();
        var fToInts = new Dictionary<int, List<int>>();
        var maxF = 0;
        
        foreach (var n in nums)
        {
            var cnt = intToF.GetValueOrDefault(n, 0);
            intToF[n] = cnt + 1;
            maxF = Math.Max(maxF, cnt + 1);
        }
        
        foreach (var item in intToF)
        {
            if (!fToInts.TryGetValue(item.Value, out var list))
            {
                list = new List<int>();
                fToInts.Add(item.Value, list);
            }
            
            list.Add(item.Key);
        }       
        
        for (var f = maxF; f >= 1; -- f)
        {
             if (fToInts.TryGetValue(f, out var list))
             {
                 foreach (var item in list)
                 {
                     res.Add(item);
                     if (res.Count == k) return res.ToArray();
                 }
             }
        }
        
        return res.ToArray();
    }
}