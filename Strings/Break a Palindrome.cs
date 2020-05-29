public class Solution 
{
    public string BreakPalindrome(string palindrome) 
    {
        var skipIdx = palindrome.Length % 2 == 1 ? palindrome.Length / 2 : -1;
        
        for (var i = 0; i < palindrome.Length; ++i)
        {
            if (i == skipIdx)
                continue;
            
            if (palindrome[i] > 'a')
            {
                return 
                    (i > 0 ? palindrome.Substring(0, i) : string.Empty) + 
                    'a' + 
                    (i < palindrome.Length - 1 ? palindrome.Substring(i + 1) : string.Empty);
            }
        }
        
        
        for (var i = palindrome.Length - 1; i >= 0; --i)
        {
            if (i == skipIdx)
                continue;
            
            if (palindrome[i] == 'a')
            {
                return 
                    (i > 0 ? palindrome.Substring(0, i) : string.Empty) + 
                    (char)('a' + 1) + 
                    (i < palindrome.Length - 1 ? palindrome.Substring(i + 1) : string.Empty);
            }
        }        
        
        
        return string.Empty;
    }
}