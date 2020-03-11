public class Solution 
{
    public int CountSubstrings(string s) 
    {
        var cnt = 0;
        
        for (var i = 0; i < 2 * s.Length - 1; ++i)
        {
            var left = i / 2;
            var right = left + i % 2;
            
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                --left;
                ++right;
                ++cnt;
            }
        }       
        
        return cnt;
    }
}