public class Solution 
{
    public IList<IList<int>> SubsetsWithDup(int[] nums) 
    {
        IList<IList<int>> res = new List<IList<int>>
        {
            new List<int>()    
        };
        
        Array.Sort(nums);
        
        for (var i = 0; i < nums.Length; ++i)
        {
            if (i - 1 >= 0 && nums[i] == nums[i - 1]) continue;
                
            SubsetsWithDup(i, nums, new List<int>(), res);
        }
        
        return res;
    }
    
    private static void SubsetsWithDup(
        int i, int[] nums,
        List<int> current, 
        IList<IList<int>> res)
    {        
        current.Add(nums[i]);
        
        res.Add(current);
        
        for (var j = i + 1; j < nums.Length; ++j)
        {
            if (j - 1 >= i + 1 && nums[j] == nums[j - 1]) continue;
            
            SubsetsWithDup(j, nums, new List<int>(current), res);
        }
    }
}