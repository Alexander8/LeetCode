public class Solution 
{
    public string StoneGameIII(int[] stoneValue) 
    {
        var len = stoneValue.Length;
        var dp = new int[len + 1];
        
        for (var i = len - 1; i >= 0; --i)
        {
            var taken = 0;
            dp[i] = int.MinValue;
            
            for (var j = i; j < Math.Min(len, i + 3); ++j)
            {
                taken += stoneValue[j];
                dp[i] = Math.Max(dp[i], taken - dp[j + 1]);
            }
        }
        
        if (dp[0] > 0) return "Alice";
        if (dp[0] < 0) return "Bob";
        return "Tie";
    }
}