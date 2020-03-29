public class Solution 
{    
    public string LongestPrefix(string s) 
    { 
        var lps = new int[s.Length];

        int i = 1, len = 0;

        while (i < s.Length)
        {
            if (s[i] == s[len])
            {
                ++len;
                lps[i] = len;
                ++i;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    ++i;
                }
            }
        }

        return s.Substring(0, lps[lps.Length - 1]);
    } 
}