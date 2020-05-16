public class Solution 
{
    public int TwoCitySchedCost(int[][] costs) 
    {
        var sortedCosts = costs.OrderByDescending(x => Math.Abs(x[0] - x[1]));        
        var count = costs.Length / 2;
        var a = 0;
        var b = 0;
        var cost = 0;
        
        foreach (var c in sortedCosts)
        {
            if (c[0] > c[1] && b < count || a == count)
            {
                ++b;
                cost += c[1];
            }
            else
            {
                ++a;
                cost += c[0];
            }
        }
        
        return cost;
    }
}