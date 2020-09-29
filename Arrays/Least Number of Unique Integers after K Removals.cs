public class Solution 
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k) 
    {
        var itemToCnt = arr.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
        var uniqueItems = itemToCnt.Count;
        
        var cntToItem = new Dictionary<int, List<int>>();
        var minCnt = int.MaxValue;
        
        foreach (var item in itemToCnt)
        {
            if (!cntToItem.TryGetValue(item.Value, out var list))   
            {
                list = new List<int>();
                cntToItem.Add(item.Value, list);
            }
            
            list.Add(item.Key);
            
            minCnt = Math.Min(minCnt, item.Value);
        }    
        
        while (k > 0)
        {
            if (cntToItem.TryGetValue(minCnt, out var list))
            {
                if (k >= list.Count * minCnt)
                {
                    k -= list.Count * minCnt;
                    uniqueItems -= list.Count;
                }
                else
                {
                    uniqueItems -= k / minCnt;
                    k = 0;
                }
            }
            
            ++minCnt;
        }
        
        return uniqueItems;
    }
}