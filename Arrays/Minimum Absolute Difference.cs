public class Solution 
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr) 
    {
        Array.Sort(arr);
        
        var min = Math.Abs(arr[1] - arr[0]);
        
        for (var i = 2; i < arr.Length; ++i)
            min = Math.Min(min, Math.Abs(arr[i] - arr[i - 1]));
        
        var res = new List<IList<int>>();
        
        for (var i = 1; i < arr.Length; ++i)
            if (Math.Abs(arr[i] - arr[i - 1]) == min)
                res.Add(new List<int> { arr[i - 1], arr[i] });
        
        return res;
    }
}