public class Solution 
{
    public bool CheckInclusion(string s1, string s2)
    {
        var memo = new int[26];

        foreach (var c in s1)
            memo[c - 'a']++;

        var i = 0;
        var seqStart = -1;
        var seqLength = 0;
        var m = new int[memo.Length];
        Array.Copy(memo, m, m.Length);

        while (i < s2.Length)
        {
            var isInSeq = m[s2[i] - 'a']-- > 0;

            if (isInSeq)
            {
                if (seqLength == 0) seqStart = i;

                ++seqLength;

                if (seqLength == s1.Length) return true;

                ++i;
            }
            else
            {
                if (seqStart >= 0) i = seqStart + 1;
                else ++i;

                if (seqLength > 0)
                    Array.Copy(memo, m, m.Length);

                seqStart = -1;
                seqLength = 0;
            }
        }

        return false;
    }
}