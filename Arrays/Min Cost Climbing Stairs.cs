public int MinCostClimbingStairs(int[] cost) 
{
    if (cost.Length == 0) return 0;
    if (cost.Length == 1) return cost[0];      
    
    var dp = new int[cost.Length + 1];
    
    dp[0] = cost[0];
    dp[1] = cost[1];
    
    for (var i = 2; i <= cost.Length; ++i)
    {
        var c = i == cost.Length ? 0 : cost[i];
        dp[i] = c + Math.Min(dp[i - 1], dp[i - 2]);
    }
    
    return dp[cost.Length];
}