public class Solution 
{
    public string LongestPalindrome(string s) 
    {        
        if (string.IsNullOrEmpty(s)) return string.Empty;
        
        var start = 0;
        var length = int.MinValue;
        
        for (var i = 0; i < s.Length * 2 - 1; ++i)
        {
            var left = i / 2;
            var right = i / 2 + i % 2;
            
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                if (right - left + 1 > length)
                {
                    length = right - left + 1;
                    start = left;
                }
                
                --left;
                ++right;
            }
        }
        
        return s.Substring(start, length);
    }
}