public class Solution 
{
    public int MinSteps(string s, string t) 
    {
        var cnt = 0; 
        var map = new int[26]; 
  
        for (var i = 0; i < s.Length; ++i)  
            map[s[i] - 'a']++;  
  
        for (var i = 0; i < t.Length; ++i)  
            if (map[t[i] - 'a']-- <= 0) 
                cnt++; 
          
        return cnt; 
    }
}