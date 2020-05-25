public class Solution
{
    public int MaxVowels(string s, int k)
    {
        var start = 0;
        var stop = 0;
        var max = int.MinValue;
        var current = 0;

        while (start + k - 1 < s.Length)
        {
            if (IsVowel(s[stop]))
                ++current;

            if (stop - start + 1 < k)
            {
                ++stop;
            }
            else
            {
                max = Math.Max(max, current);

                if (IsVowel(s[start]))
                    --current;

                ++start;
                ++stop;
            }
        }

        return max != int.MinValue ? max : 0;
    }

    private static bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}