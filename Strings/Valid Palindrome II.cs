public class Solution 
{
    public bool ValidPalindrome(string s) 
    {
        for (var i = 0; i < s.Length / 2; ++i)
        {
            if (s[i] == s[s.Length - 1 - i]) continue;
            
            return 
                IsPalindrome(s.Substring(0, i) + s.Substring(i + 1))
                ||
                IsPalindrome(s.Substring(0, s.Length - 1 - i) + s.Substring(s.Length - i));
        }
        
        return true;
    }
    
    private static bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length / 2; ++i)
            if (s[i] != s[s.Length - 1 - i]) return false;
        
        return true;
    }
}