public class Solution 
{
    public int CoinChange(int[] coins, int amount) 
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue);
        
        dp[0] = 0;
        
        Array.Sort(coins);
        
        for (var i = 1; i <= amount; ++i)
        {
            for (var j = 0; j < coins.Length; ++j)
            {
                if (coins[j] > i) break;
                
                if (dp[i - coins[j]] != int.MaxValue)
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
            }
        }
        
        return dp[amount] == int.MaxValue ? -1 : dp[amount];
    }
}