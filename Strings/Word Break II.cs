public class Solution 
{
    public IList<string> WordBreak(string s, IList<string> wordDict) 
    {
        var dp = new List<string>[s.Length + 1];
        dp[0] = new List<string>();

        for (var i = 1; i <= s.Length; ++i)
        {
            foreach (var w in wordDict)
            {
                if (w.Length <= i && dp[i - w.Length] != null)
                {
                    var substr = s.Substring(i - w.Length, w.Length);
                    if (string.CompareOrdinal(substr, w) == 0)
                    {
                        if (dp[i] == null)
                            dp[i] = new List<string>();
                        dp[i].Add(w);
                    }
                }
            }
        }

        if (dp[s.Length] == null)
            return new List<string>();

        var res = new List<List<string>>();

        Fill(res, dp, s.Length, new List<string>());

        return res.Select(l => string.Join(" ", l)).ToList();
    }

    private static void Fill(List<List<string>> res, List<string>[] dp, int i, List<string> words)
    {
        if (dp[i] == null)
            return;

        if (i == 0)
        {
            res.Add(words);
            return;
        }

        foreach (var w in dp[i])
        {
            var copy = new List<string>(words);
            copy.Insert(0, w);
            Fill(res, dp, i - w.Length, copy);
        }
    }
}