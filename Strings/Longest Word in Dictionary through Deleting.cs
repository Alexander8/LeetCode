public class Solution 
{
    public string FindLongestWord(string s, IList<string> d) 
    {
        var dict = new List<string>(d);
        dict.Sort();
           
        var maxLen = 0;
        var result = string.Empty;
        
        foreach (var candidate in dict)
        {
            if (candidate.Length > maxLen && candidate.Length <= s.Length && IsSubstring(s, candidate)) 
            {
                maxLen = candidate.Length;
                result = candidate;
            }                
        }
        
        return result;
    }
    
    private static bool IsSubstring(string s, string candidate)
    {
        var j = 0;
        
        for (var i = 0; i < s.Length && j < candidate.Length; ++i)
        {
            if (s[i] == candidate[j])
                ++j;
        }
        
        return j == candidate.Length;
    }
}