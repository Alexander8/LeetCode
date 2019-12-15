public IList<IList<int>> Permute(int[] nums) 
{
    if (nums.Length == 0)
    {
        var res = new List<IList<int>>();
        res.Add(new List<int>());
        return res;
    }
    
    return Permute(new List<int>(nums));
}

private static IList<IList<int>> Permute(List<int> nums) 
{
    IList<IList<int>> res = new List<IList<int>>();
        
    if (nums.Count == 1)
    {
        res.Add(new List<int> { nums[0] });
        return res;
    }
    
    for (var i = 0; i < nums.Count; ++i)
    {
        var tmp = new List<int>(nums);
        tmp.RemoveAt(i);
        
        foreach (var p in Permute(tmp))
        {
            p.Insert(0, nums[i]);
            res.Add(p);
        }           
    }
    
    return res;
}