public class Solution 
{
    public int MinDistance(string word1, string word2) 
    {
        var dp = new int[word1.Length + 1, word2.Length + 1];
        
        for (var i = 1; i < word1.Length + 1; ++i)
            dp[i, 0] = i;
        
        for (var j = 1; j < word2.Length + 1; ++j)
            dp[0, j] = j;
        
        for (var j = 1; j < word2.Length + 1; ++j)
        {
            for (var i = 1; i < word1.Length + 1; ++i)
            {
                var replaceCost = word1[i - 1] == word2[j - 1]
                    ? 0
                    : 1;
                
                dp[i, j] = Math.Min(
                        dp[i - 1, j] + 1, 
                        Math.Min(dp[i, j - 1] + 1, 
                                 dp[i - 1, j - 1] + replaceCost));
            }
        }
        
        return dp[word1.Length, word2.Length];
    }
}