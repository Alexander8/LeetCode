public class Solution 
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums) 
    {
        var res = new List<int>();
        var map = new Dictionary<int, List<int>>();
        
        for (var i = 0; i < nums.Count; ++i)
        {
            for (var j = 0; j < nums[i].Count; ++j)
            {
                if (!map.ContainsKey(i + j))
                    map.Add(i + j, new List<int>());
                
                map[i + j].Add(nums[i][j]);
            }
        }
        
        foreach (var item in map)
        {
            for (var i = item.Value.Count - 1; i >= 0; --i)
                res.Add(item.Value[i]);
        }
        
        return res.ToArray();
    }
}