public class Solution 
{
    public IList<IList<string>> DisplayTable(IList<IList<string>> orders) 
    {
        var map = new Dictionary<int, Dictionary<string, int>>();
        var foodItems = new HashSet<string>();
        
        foreach (var order in orders)
        {
            var table = int.Parse(order[1]);
            
            if (!map.TryGetValue(table, out var torders))
            {
                torders = new Dictionary<string, int>();
                map.Add(table, torders);
            }
            
            if (!torders.TryGetValue(order[2], out var foodCnt))
            {
                foodCnt = 0;
            }
            
            torders[order[2]] = foodCnt + 1;
            
            foodItems.Add(order[2]);
        }
        
        var res = new List<IList<string>>();
        res.Add(new List<string> { "Table" });
        
        var sortedFood = foodItems.OrderBy(f => f, StringComparer.Ordinal).ToArray();
        foreach (var f in sortedFood) 
            res[0].Add(f);
        
        foreach (var table in map.OrderBy(x => x.Key))
        {
            res.Add(new List<string> { table.Key.ToString() });
            
            foreach (var f in sortedFood)
            {
                if (table.Value.TryGetValue(f, out var cnt))
                {
                    res[res.Count - 1].Add(cnt.ToString());
                }
                else
                {
                    res[res.Count - 1].Add("0");
                }
            }
        }
        
        return res;
    }
}