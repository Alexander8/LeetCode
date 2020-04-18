public class Solution 
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        var combinations = new List<IList<int>>();
        CombinationSum(candidates, target, 0, 0, new List<int>(), combinations);
        return combinations;
    }
    
    private static void CombinationSum(int[] candidates, int target, int j, int sum, List<int> combination, List<IList<int>> combinations)
    {
        if (sum > target) 
            return;
        
        if (sum == target)
        {
            combinations.Add(new List<int>(combination));
            return;
        }
        
        for (var i = j; i < candidates.Length; ++i)
        {
            combination.Add(candidates[i]);
            CombinationSum(candidates, target, i, sum + candidates[i], combination, combinations);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}