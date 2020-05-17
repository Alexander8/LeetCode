public class Solution 
{    
    private static readonly int[] mapTmp = new int[26];
    
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
        
        var contains = true;

        for (var i = 0; i < p.Length; ++i)
        {
            sumTmp += s[i] - 'a';
            if (map[s[i] - 'a'] == 0)
                contains = false;
        }

        if (contains && sum == sumTmp && Check(s, p, 0, map))
            res.Add(0);

        for (var i = p.Length; i < s.Length; ++i)
        {
            sumTmp -= s[i - p.Length] - 'a';
            sumTmp += s[i] - 'a';

            if (map[s[i] - 'a'] > 0 && sum == sumTmp && Check(s, p, i - p.Length + 1, map))
                res.Add(i - p.Length + 1);
        }

        return res;
    }

    private static bool Check(string s, string p, int start, int[] map)
    {
        Array.Copy(map, mapTmp, mapTmp.Length);

        for (var i = start; i < start + p.Length; ++i)
        {
            if (mapTmp[s[i] - 'a'] == 0)
                return false;

            mapTmp[s[i] - 'a'] -= 1;
        }

        return mapTmp.All(x => x == 0);
    }
}    