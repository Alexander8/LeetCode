public class Solution
{
    private const int Base = 25;
    private const long Modulo = 999999999989;

    public string LongestDupSubstring(string S)
    {
        var lo = 1;
        var hi = S.Length - 1;
        var result = string.Empty;

        while (lo <= hi)
        {
            var m = lo + (hi - lo) / 2;
            var hasDuplicate = false;
            var map = new Dictionary<long, List<int>>();

            var (hash, maxPowerOfBase) = GetHash(S, m);
            map.Add(hash, new List<int> { 0 });

            for (var i = m; i < S.Length; ++i)
            {
                hash = hash - (maxPowerOfBase * (S[i - m] - 'a')) % Modulo;
                if (hash < 0) hash += Modulo;

                hash = (hash * Base + (S[i] - 'a')) % Modulo;

                if (!map.TryGetValue(hash, out var list))
                {
                    list = new List<int> { i - m + 1 };
                    map.Add(hash, list);
                }
                else
                {
                    var candidate = S.Substring(i - m + 1, m);
                    foreach (var pos in list)
                    {
                        var str = S.Substring(pos, m);
                        if (string.CompareOrdinal(candidate, str) == 0)
                        {
                            hasDuplicate = true;
                            break;
                        }
                    }

                    list.Add(i - m + 1);

                    if (hasDuplicate)
                    {
                        result = candidate;
                        break;
                    }
                }
            }

            if (hasDuplicate)
                lo = m + 1;
            else
                hi = m - 1;
        }

        return result;
    }

    private static (long hash, long maxPowerOfBase) GetHash(string s, int len)
    {
        long hash = 0;
        long maxPowerOfBase = 1;

        for (var i = 0; i < len; ++i)
        {
            hash = (hash * Base + (s[i] - 'a')) % Modulo;
            if (i < len - 1)
                maxPowerOfBase = (maxPowerOfBase * Base) % Modulo;
        }

        return (hash, maxPowerOfBase);
    }
}