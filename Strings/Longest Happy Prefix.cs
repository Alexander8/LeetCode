public class Solution 
{    
    public string LongestPrefix(string s) 
    { 
        var lps = new int[s.Length];  
        var len = 0; 

        var i = 1; 
      
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
                    lps[i] = 0; 
                    i++; 
                } 
            } 
        } 
      
        return s.Substring(0, len); 
    } 
}