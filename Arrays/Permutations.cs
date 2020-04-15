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

// #2
public class Solution 
{
    public IList<IList<int>> Permute(int[] nums) 
    {
        var permutations = new List<IList<int>>();
        
        GetPermutations(nums, 0, permutations);
        
        return permutations;
    }
    
    private static void GetPermutations(int[] arr, int i, List<IList<int>> permutations)
    {
        if (i == arr.Length)
        {
            var arrTmp = new List<int>(arr);
            permutations.Add(arrTmp);
        }
        else
        {
            for (var j = i; j < arr.Length; ++j)
            {
                Swap(arr, i, j);
                GetPermutations(arr, i + 1, permutations);
                Swap(arr, i, j);
            }
        }
    }

    private static void Swap(int[] arr, int i, int j)
    {
        var item = arr[i];
        arr[i] = arr[j];
        arr[j] = item;
    }
}