public class Solution 
{        
    public IList<int> FindAnagrams(string s, string p) 
    {
        var map = new int[26];
        int sum = 0, sumTmp = 0;
        var res = new List<int>();

        if (s.Length < p.Length)
            return res;

        foreach (var c in p)
        {
            map[c - 'a'] += 1;
            sum += c - 'a';
        }

        var start = 0;

        for (var i = 0; i < s.Length; ++i)
        {
            if (map[s[i] - 'a'] == 0)
            {
                sumTmp = 0;
                start = i + 1;
                continue;
            }

            sumTmp += s[i] - 'a';
            if (i - start + 1 > p.Length)
            {
                sumTmp -= s[i - p.Length] - 'a';
                ++start;
            }

            if (sum == sumTmp && i - start + 1 == p.Length)
                res.Add(start);
        }

        return res;
    }
}    