public class Solution 
{
    const int Base = 26;
    const int Modulo = 100_003;

    public string LongestPrefix(string s)
    {
        var hash = GetHash(s, out var maxPowerOfBase);

        var prefixHash = hash;
        var suffixHash = hash;
        var basePrefixMultiplier = 1;

        for (var len = s.Length - 1; len >= 1; --len)
        {
            prefixHash = prefixHash - (s[len] * basePrefixMultiplier) % Modulo;
            if (prefixHash < 0) prefixHash += Modulo;

            basePrefixMultiplier = (basePrefixMultiplier * Base) % Modulo;

            suffixHash = ((suffixHash - s[s.Length - 1 - len] * maxPowerOfBase) * Base) % Modulo;
            if (suffixHash < 0) suffixHash += Modulo;

            if (prefixHash == suffixHash)
            {
                var equals = true;

                for (var i = 0; i < len; ++i)
                {
                    if (s[i] != s[s.Length - len + i])
                    {
                        equals = false;
                        break;
                    }
                }

                if (equals)
                    return s.Substring(0, len);
            }
        }

        return string.Empty;
    }

    private static int GetHash(string s, out int maxPowerOfBase)
    {
        var hash = 0;

        maxPowerOfBase = 1;

        for (var i = 0; i < s.Length; ++i)
        {
            hash = (hash * Base + s[i]) % Modulo;

            if (i < s.Length - 1)
                maxPowerOfBase = (maxPowerOfBase * Base) % Modulo;
        }

        return hash;
    }
}