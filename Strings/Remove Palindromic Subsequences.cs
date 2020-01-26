public class Solution 
{
    public int RemovePalindromeSub(string s) 
    {
        if (string.IsNullOrEmpty(s)) return 0;
        
        if (IsPalindrome(s)) return 1;
        
        return 2;
    }
    
    private static bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length / 2; ++i)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }
        
        return true;
    }
}