public class Solution 
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var dp = new bool[s.Length + 1];

        dp[0] = true;

        for (var i = 1; i <= s.Length; ++i)
        {
            foreach (var word in wordDict)
            {
                if (word.Length <= i && dp[i - word.Length])
                {
                    if (string.CompareOrdinal(s.Substring(i - word.Length, word.Length), word) == 0)
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
        }

        return dp[s.Length];
    }
}