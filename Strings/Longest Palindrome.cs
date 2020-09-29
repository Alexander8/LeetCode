public class Solution 
{
    public int LongestPalindrome(string s) 
    {
        var map = new Dictionary<char, int>();
        
        foreach (var c in s)
        {
            var cnt = map.GetValueOrDefault(c, 0);
            map[c] = cnt + 1;
        }
        
        var len = 0;
        var hasOne = false;
        
        foreach (var cnt in map.Values)
        {
            if (cnt % 2 == 0)
                len += cnt;
            else if (cnt > 2)
            {
                len += cnt - 1;
                hasOne = true;
            }
            else
                hasOne = true;                
        }
        
        return hasOne ? len + 1 : len;
    }
}