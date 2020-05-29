public class Solution 
{
    public int LongestStrChain(string[] words)
    {
        var dp = new int[words.Length];
        var lengthMap = new int[1001];
        var sumMap = new int[1001];
        var maxLen = 0;

        words = words.OrderBy(w => w.Length).ToArray();

        Array.Fill(lengthMap, -1);

        for (var i = 0; i < words.Length; ++i)
        {
            lengthMap[words[i].Length] = i;
            sumMap[i] = words[i].Select(c => c - 'a').Sum();
        }

        for (var i = 1; i < words.Length; ++i)
        {
            var next = words[i];

            for (var j = lengthMap[next.Length - 1]; j >= 0; --j)
            {
                var prev = words[j];
                if (prev.Length + 1 != next.Length) break;

                if (sumMap[i] - sumMap[j] > 25 || !CanProceed(prev, next)) continue;

                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            maxLen = Math.Max(maxLen, dp[i]);
        }

        return maxLen + 1;
    }

    private static bool CanProceed(string prev, string next)
    {
        var nextArr = new int[26];
        foreach (var c in next)
            nextArr[c - 'a'] += 1;

        foreach (var c in prev)
        {
            if (nextArr[c - 'a'] == 0)
                return false;

            nextArr[c - 'a'] -= 1;
        }

        return nextArr.Sum() == 1;
    }
}